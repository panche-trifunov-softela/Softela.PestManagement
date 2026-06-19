using MediatR;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Program.CreateProgram;

public sealed record CreateProgramRequest : IRequest<int>
{
    public int EstimateId { get; init; }
    public int CfgProgramId { get; init; }
    public bool Status { get; init; }
    public string? Notes { get; init; }
    public DateTimeOffset StartDate { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public DateTimeOffset? RenewalDate { get; init; }
    public ProgramFrequency Frequency { get; init; }
}
