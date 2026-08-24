using MediatR;
using Softela.PestManagement.Application.Dtos;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Customer.UpdateCustomer;

public sealed record UpdateCustomerRequest : IRequest<bool>
{
    public int Id { get; init; }
    public string Name { get; init; }
    public CustomerType CustomerType { get; init; }
    public bool IsActive { get; init; }
    public bool SendInvoice { get; init; }
    public bool EmailInvoice { get; init; }
    public string Instructions { get; init; }
    public string PrimaryNote { get; init; }
    public string RegistrationNum { get; init; }
    public string PreferredContactMethod { get; init; }
    public BillingAddressDto BillingAddress { get; init; }
    public BillingContactDto BillingContact { get; init; }
}
