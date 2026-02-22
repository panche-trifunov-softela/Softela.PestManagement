using MediatR;

namespace Softela.PestManagement.Application.Queries.Customer.GetCustomers;

public sealed record GetCustomersRequest : IRequest<GetCustomersResponse>;
