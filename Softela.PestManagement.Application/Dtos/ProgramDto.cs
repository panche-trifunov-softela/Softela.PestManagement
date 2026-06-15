using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Dtos;

public sealed record ProgramDto
{
    public int Id { get; init; }
    public int OpsEstimateId { get; init; }
    public int CfgProgramId { get; set; }
    public bool Status { get; init; }
    public string? Notes { get; init; }
    public DateTimeOffset StartDate { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public DateTimeOffset? RenewalDate { get; init; }
    public DateTimeOffset? CanceledDate { get; init; }
    public DateTimeOffset? PendingCancelDate { get; init; }
    public ProgramFrequency Frequency { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
