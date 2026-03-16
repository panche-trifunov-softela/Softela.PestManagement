using MediatR;

namespace Softela.PestManagement.Application.Commands.ServiceAddress.DeleteServiceAddress;

public sealed record DeleteServiceAddressRequest : IRequest<bool>
{
    public int Id { get; init; }
}
