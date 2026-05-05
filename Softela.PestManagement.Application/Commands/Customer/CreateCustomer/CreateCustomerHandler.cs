using System.Text.Json;
using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Events;
using Softela.PestManagement.Application.Outbox;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Customer.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, int>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerContactRepository _contactRepository;
    private readonly IOutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITenantContext _tenantContext;

    public CreateCustomerHandler(
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

    public async Task<int> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customerType = Enum.Parse<CustomerType>(request.CustomerType, ignoreCase: true);
        var now = DateTime.UtcNow;
        var nowOffset = DateTimeOffset.UtcNow;
        var userId = _tenantContext.UserId;

        var customer = new Domain.Entities.Customer
        {
            TenantId = _tenantContext.TenantId,
            CustomerNum = $"CUST-{DateTime.UtcNow:yyyyMMddHHmmss}",
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
            IsDeleted = false,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };

        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var customerId = await _customerRepository.CreateAsync(customer);
            await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                new CustomerCreatedEvent(customerId, customer.TenantId, customer.Name), nowOffset));

            if (request.BillingContact != null)
            {
                var contact = new CustomerContact
                {
                    TenantId = _tenantContext.TenantId,
                    CustomerId = customerId,
                    ContactType = ContactType.Billing.ToString(),
                    FirstName = request.BillingContact.FirstName,
                    MiddleName = request.BillingContact.MiddleName,
                    LastName = request.BillingContact.LastName,
                    Email = request.BillingContact.Email,
                    AlternateEmails = request.BillingContact.AlternateEmails != null
                        ? JsonSerializer.Serialize(request.BillingContact.AlternateEmails)
                        : null,
                    IsDeleted = false,
                    CreatedAt = now,
                    ModifiedAt = now,
                    CreatedBy = userId,
                    ModifiedBy = userId
                };

                var contactId = await _contactRepository.UpsertAsync(contact);
                await _outboxRepository.InsertAsync(OutboxMessageFactory.Create(
                    new CustomerContactUpsertedEvent(contactId, customerId, customer.TenantId), nowOffset));

                // TODO: create stored procedure for UpsertPhones in batch and Inserting in Outbox table in batch
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
                            new CustomerContactPhoneUpsertedEvent(phoneId, contactId, customer.TenantId), nowOffset));
                    }
                }
            }

            await _unitOfWork.CommitAsync(cancellationToken);
            return customerId;
        }
        catch
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
