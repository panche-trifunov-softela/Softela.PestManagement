using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEvent.UpdateCfgEvent;

public sealed record UpdateCfgEventRequest : IRequest<bool>
{
    public int Id { get; init; }
    public required string Name { get; init; }
}
