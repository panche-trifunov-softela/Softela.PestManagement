using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEvent.CreateCfgEvent;

public sealed record CreateCfgEventRequest : IRequest<int>
{
    public required string Name { get; init; }
}
