using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.Customer.GetCustomers;

public sealed record GetCustomersResponse
{
    public List<CustomerDto> Data { get; init; }
}

public sealed record CustomerDto
{
    public int Id { get; init; }
    public string CustomerNum { get; init; }
    public string Name { get; init; }
    public int CustomerType { get; init; }
    public bool IsActive { get; init; }
    public bool SendInvoice { get; init; }
    public bool EmailInvoice { get; init; }
    public string Instructions { get; init; }
    public string PrimaryNote { get; init; }
    public string RegistrationNum { get; init; }
    public string PreferredContactMethod { get; init; }
    public BillingAddressDto BillingAddress { get; init; }
    public BillingContactDto BillingContact { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
