using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddressById;

public sealed record GetServiceAddressByIdResponse
{
    public ServiceAddressDto Data { get; init; }
}
