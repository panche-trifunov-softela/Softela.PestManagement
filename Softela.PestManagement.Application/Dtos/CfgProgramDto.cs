namespace Softela.PestManagement.Application.Dtos;

public sealed record CfgProgramDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
