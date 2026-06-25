using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgCadence.DeleteCfgCadence;

public sealed record DeleteCfgCadenceRequest : IRequest<bool>
{
    public int Id { get; init; }
}
