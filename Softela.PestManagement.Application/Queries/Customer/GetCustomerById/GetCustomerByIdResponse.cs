using Softela.PestManagement.Application.Dtos;
using Softela.PestManagement.Application.Queries.Customer.GetCustomers;

namespace Softela.PestManagement.Application.Queries.Customer.GetCustomerById;

public sealed record GetCustomerByIdResponse
{
    public CustomerDto Data { get; init; }
}
