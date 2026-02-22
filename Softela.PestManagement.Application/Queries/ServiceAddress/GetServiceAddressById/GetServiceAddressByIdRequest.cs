using MediatR;

namespace Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddressById;

public sealed record GetServiceAddressByIdRequest : IRequest<GetServiceAddressByIdResponse>
{
    public int Id { get; init; }
}
