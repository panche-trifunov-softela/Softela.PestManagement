namespace Softela.PestManagement.Application.Dtos;

public sealed record CfgRouteDto
{
    public int Id { get; init; }
    public int CfgEmployeeId { get; init; }
    public required string Name { get; init; }
    public bool IsActive { get; init; }
    public string? Note { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
