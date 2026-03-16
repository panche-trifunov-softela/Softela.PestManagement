using System.Text.Json;
using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Dtos;
using Softela.PestManagement.Application.Queries.Customer.GetCustomers;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Customer.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequest, GetCustomerByIdResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerContactRepository _contactRepository;
    private readonly ITenantContext _tenantContext;

    public GetCustomerByIdHandler(
        ICustomerRepository customerRepository,
        ICustomerContactRepository contactRepository,
        ITenantContext tenantContext)
    {
        _customerRepository = customerRepository;
        _contactRepository = contactRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id, _tenantContext.TenantId);
        if (customer == null)
            return new GetCustomerByIdResponse { Data = null };

        var contacts = await _contactRepository.GetByCustomerIdAsync(customer.Id, _tenantContext.TenantId);
        var billingContact = contacts.FirstOrDefault(c => c.ContactType == "Billing");

        BillingContactDto contactDto = null;
        if (billingContact != null)
        {
            var phoneEntities = await _contactRepository.GetPhonesByContactIdAsync(billingContact.Id, _tenantContext.TenantId);
            var phones = phoneEntities.Select(p => new PhoneDto
            {
                Type = p.PhoneType,
                Number = p.PhoneNumber
            }).ToArray();

            contactDto = new BillingContactDto
            {
                FirstName = billingContact.FirstName,
                MiddleName = billingContact.MiddleName,
                LastName = billingContact.LastName,
                Email = billingContact.Email,
                AlternateEmails = !string.IsNullOrEmpty(billingContact.AlternateEmails)
                    ? JsonSerializer.Deserialize<string[]>(billingContact.AlternateEmails)
                    : [],
                Phones = phones
            };
        }

        return new GetCustomerByIdResponse
        {
            Data = new CustomerDto
            {
                Id = customer.Id,
                CustomerNum = customer.CustomerNum,
                Name = customer.Name,
                CustomerType = (int)customer.CustomerType,
                IsActive = customer.IsActive,
                SendInvoice = customer.SendInvoice,
                EmailInvoice = customer.EmailInvoice,
                Instructions = customer.Instructions,
                PrimaryNote = customer.PrimaryNote,
                RegistrationNum = customer.RegistrationNum,
                PreferredContactMethod = customer.PreferredContactMethod,
                BillingAddress = new BillingAddressDto
                {
                    Street = customer.BillingAddressStreet,
                    City = customer.BillingAddressCity,
                    State = customer.BillingAddressState,
                    Zip = customer.BillingAddressZip
                },
                BillingContact = contactDto,
                CreatedAt = customer.CreatedAt,
                ModifiedAt = customer.ModifiedAt
            }
        };
    }
}
