namespace Softela.PestManagement.Application.Dtos;

public sealed record CfgProgramEventCadenceDto
{
    public int Id { get; init; }
    public int CfgProgramId { get; init; }
    public int CfgEventId { get; init; }
    public int CfgCadenceId { get; init; }
    public decimal Interval { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
