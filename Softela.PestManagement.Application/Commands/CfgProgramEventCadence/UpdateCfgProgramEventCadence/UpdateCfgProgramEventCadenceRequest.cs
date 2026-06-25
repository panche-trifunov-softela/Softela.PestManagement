using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.UpdateCfgProgramEventCadence;

public sealed record UpdateCfgProgramEventCadenceRequest : IRequest<bool>
{
    public int Id { get; init; }
    public int CfgProgramId { get; init; }
    public int CfgEventId { get; init; }
    public int CfgCadenceId { get; init; }
    public decimal Interval { get; init; }
}
