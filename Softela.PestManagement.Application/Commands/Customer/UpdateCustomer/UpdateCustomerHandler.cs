using System.Text.Json;
using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Customer.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerContactRepository _contactRepository;
    private readonly ITenantContext _tenantContext;

    public UpdateCustomerHandler(
        ICustomerRepository customerRepository,
        ICustomerContactRepository contactRepository,
        ITenantContext tenantContext)
    {
        _customerRepository = customerRepository;
        _contactRepository = contactRepository;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customerType = Enum.Parse<CustomerType>(request.CustomerType, ignoreCase: true);
        var now = DateTime.UtcNow;
        var userId = _tenantContext.UserId;

        var customer = new Domain.Entities.Customer
        {
            Id = request.Id,
            TenantId = _tenantContext.TenantId,
            Name = request.Name,
            CustomerType = customerType,
            IsActive = request.IsActive,
            SendInvoice = request.SendInvoice,
            EmailInvoice = request.EmailInvoice,
            Instructions = request.Instructions,
            PrimaryNote = request.PrimaryNote,
            RegistrationNum = request.RegistrationNum,
            PreferredContactMethod = request.PreferredContactMethod,
            BillingAddressStreet = request.BillingAddress?.Street,
            BillingAddressCity = request.BillingAddress?.City,
            BillingAddressState = request.BillingAddress?.State,
            BillingAddressZip = request.BillingAddress?.Zip,
            ModifiedAt = now,
            ModifiedBy = userId
        };

        await _customerRepository.UpdateAsync(customer);

        if (request.BillingContact != null)
        {
            var existingContacts = await _contactRepository.GetByCustomerIdAsync(request.Id, _tenantContext.TenantId);
            var existingBilling = existingContacts.FirstOrDefault(c => c.ContactType == "Billing");

            var contact = new CustomerContact
            {
                Id = existingBilling?.Id ?? 0,
                TenantId = _tenantContext.TenantId,
                CustomerId = request.Id,
                ContactType = "Billing",
                FirstName = request.BillingContact.FirstName,
                MiddleName = request.BillingContact.MiddleName,
                LastName = request.BillingContact.LastName,
                Email = request.BillingContact.Email,
                AlternateEmails = request.BillingContact.AlternateEmails != null
                    ? JsonSerializer.Serialize(request.BillingContact.AlternateEmails)
                    : null,
                IsDeleted = false,
                CreatedAt = existingBilling?.CreatedAt ?? now,
                ModifiedAt = now,
                CreatedBy = existingBilling?.CreatedBy ?? userId,
                ModifiedBy = userId
            };

            var contactId = await _contactRepository.UpsertAsync(contact);

            // Replace phones: delete existing, then insert new
            await _contactRepository.DeletePhonesByContactIdAsync(contactId, _tenantContext.TenantId);

            if (request.BillingContact.Phones != null)
            {
                foreach (var phone in request.BillingContact.Phones)
                {
                    await _contactRepository.UpsertPhoneAsync(new CustomerContactPhone
                    {
                        TenantId = _tenantContext.TenantId,
                        CustomerContactId = contactId,
                        PhoneType = phone.Type,
                        PhoneNumber = phone.Number,
                        IsDeleted = false,
                        CreatedAt = now,
                        ModifiedAt = now
                    });
                }
            }
        }

        return true;
    }
}
