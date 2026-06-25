using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.CreateCfgProgramEventCadence;

public sealed record CreateCfgProgramEventCadenceRequest : IRequest<int>
{
    public int CfgProgramId { get; init; }
    public int CfgEventId { get; init; }
    public int CfgCadenceId { get; init; }
    public decimal Interval { get; init; }
}
