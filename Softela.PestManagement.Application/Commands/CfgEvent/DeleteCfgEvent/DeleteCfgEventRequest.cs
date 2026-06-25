using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEvent.DeleteCfgEvent;

public sealed record DeleteCfgEventRequest : IRequest<bool>
{
    public int Id { get; init; }
}
