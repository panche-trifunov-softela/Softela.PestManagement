using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgCadence.CreateCfgCadence;

public sealed record CreateCfgCadenceRequest : IRequest<int>
{
    public required string Name { get; init; }
}
