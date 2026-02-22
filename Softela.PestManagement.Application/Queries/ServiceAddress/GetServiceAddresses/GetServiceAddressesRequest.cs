using MediatR;

namespace Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddresses;

public sealed record GetServiceAddressesRequest : IRequest<GetServiceAddressesResponse>
{
    public int CustomerId { get; init; }
}
