using System.Text.Json;
using MediatR;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Dtos;
using Softela.PestManagement.Application.Repositories;

namespace Softela.PestManagement.Application.Queries.Customer.GetCustomers;

public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerContactRepository _contactRepository;
    private readonly ITenantContext _tenantContext;

    public GetCustomersHandler(
        ICustomerRepository customerRepository,
        ICustomerContactRepository contactRepository,
        ITenantContext tenantContext)
    {
        _customerRepository = customerRepository;
        _contactRepository = contactRepository;
        _tenantContext = tenantContext;
    }

    public async Task<GetCustomersResponse> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetByTenantIdAsync(_tenantContext.TenantId);
        var dtos = new List<CustomerDto>();

        foreach (var customer in customers)
        {
            var contacts = await _contactRepository.GetByCustomerIdAsync(customer.Id, _tenantContext.TenantId);
            var billingContact = contacts.FirstOrDefault(c => c.ContactType == "Billing");

            dtos.Add(MapToDto(customer, billingContact));
        }

        return new GetCustomersResponse { Data = dtos };
    }

    private static CustomerDto MapToDto(Domain.Entities.Customer customer, Domain.Entities.CustomerContact billingContact)
    {
        BillingContactDto contactDto = null;
        if (billingContact != null)
        {
            contactDto = new BillingContactDto
            {
                FirstName = billingContact.FirstName,
                MiddleName = billingContact.MiddleName,
                LastName = billingContact.LastName,
                Email = billingContact.Email,
                AlternateEmails = !string.IsNullOrEmpty(billingContact.AlternateEmails)
                    ? JsonSerializer.Deserialize<string[]>(billingContact.AlternateEmails)
                    : [],
                Phones = []
            };
        }

        return new CustomerDto
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
        };
    }
}
