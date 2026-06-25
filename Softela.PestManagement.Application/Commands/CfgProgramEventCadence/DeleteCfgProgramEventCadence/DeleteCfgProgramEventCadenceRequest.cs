using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.DeleteCfgProgramEventCadence;

public sealed record DeleteCfgProgramEventCadenceRequest : IRequest<bool>
{
    public int Id { get; init; }
}
