using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Dtos;

public sealed record CfgEmployeeDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string CertificationNumber { get; init; }
    public required string EmployeeNumber { get; init; }
    public EmployeeRole Role { get; init; }
    public bool IsActive { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset ModifiedAt { get; init; }
}
