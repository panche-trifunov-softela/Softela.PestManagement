using MediatR;

namespace Softela.PestManagement.Application.Queries.Customer.GetCustomerById;

public sealed record GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
{
    public int Id { get; init; }
}
