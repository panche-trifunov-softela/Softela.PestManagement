using System.Text.Json;
using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Customer.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerContactRepository _contactRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public UpdateCustomerHandler(
        ICustomerRepository customerRepository,
        ICustomerContactRepository contactRepository,
        IOutboxRepository outboxRepository,
        IUnitOfWork unitOfWork,
        ITenantContext tenantContext)
    {
        _customerRepository = customerRepository;
        _contactRepository = contactRepository;
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
        _tenantContext = tenantContext;
    }

    public async Task<bool> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var nowOffset = DateTimeOffset.UtcNow;
        var userId = _tenantContext.UserId;

        var customer = new Domain.Entities.Customer
        {
            Id = request.Id,
            TenantId = _tenantContext.TenantId,
            Name = request.Name,
            CustomerType = request.CustomerType,
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

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            await _customerRepository.UpdateAsync(customer);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new CustomerUpdatedEvent(customer.Id, customer.TenantId, customer.Name), nowOffset));

            if (request.BillingContact != null)
            {
                var existingContacts = await _contactRepository.GetByCustomerIdAsync(request.Id, _tenantContext.TenantId);
                var existingBilling = existingContacts.FirstOrDefault(c => c.ContactType == ContactType.Billing.ToString());

                var contact = new CustomerContact
                {
                    Id = existingBilling?.Id ?? 0,
                    TenantId = _tenantContext.TenantId,
                    CustomerId = request.Id,
                    ContactType = ContactType.Billing.ToString(),
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
                await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                    new CustomerContactUpsertedEvent(contactId, request.Id, _tenantContext.TenantId), nowOffset));

                await _contactRepository.DeletePhonesByContactIdAsync(contactId, _tenantContext.TenantId, now, userId);
                await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                    new CustomerContactPhoneDeletedEvent(contactId, _tenantContext.TenantId), nowOffset));

                if (request.BillingContact.Phones != null)
                {
                    foreach (var phone in request.BillingContact.Phones)
                    {
                        var phoneId = await _contactRepository.UpsertPhoneAsync(new CustomerContactPhone
                        {
                            TenantId = _tenantContext.TenantId,
                            CustomerContactId = contactId,
                            PhoneType = phone.Type,
                            PhoneNumber = phone.Number,
                            IsDeleted = false,
                            CreatedAt = now,
                            ModifiedAt = now
                        });
                        await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                            new CustomerContactPhoneUpsertedEvent(phoneId, contactId, _tenantContext.TenantId), nowOffset));
                    }
                }
            }

            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
