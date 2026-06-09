using MediatR;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.Program.UpdateProgram;

public sealed record UpdateProgramRequest : IRequest<bool>
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public bool Status { get; init; }
    public string? Notes { get; init; }
    public DateTimeOffset StartDate { get; init; }
    public DateTimeOffset? EndDate { get; init; }
    public DateTimeOffset? RenewalDate { get; init; }
    public DateTimeOffset? CanceledDate { get; init; }
    public DateTimeOffset? PendingCancelDate { get; init; }
    public ProgramFrequency Frequency { get; init; }
}
