using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgCadence.UpdateCfgCadence;

public sealed record UpdateCfgCadenceRequest : IRequest<bool>
{
    public int Id { get; init; }
    public required string Name { get; init; }
}
