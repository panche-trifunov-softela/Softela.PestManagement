using MediatR;

namespace Softela.PestManagement.Application.Commands.Customer.DeleteCustomer;

public sealed record DeleteCustomerRequest : IRequest<bool>
{
    public int Id { get; init; }
}
