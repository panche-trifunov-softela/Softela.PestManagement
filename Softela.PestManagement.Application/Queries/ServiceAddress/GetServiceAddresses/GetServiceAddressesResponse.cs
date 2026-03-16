using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddresses;

public sealed record GetServiceAddressesResponse
{
    public List<ServiceAddressDto> Data { get; init; }
}
