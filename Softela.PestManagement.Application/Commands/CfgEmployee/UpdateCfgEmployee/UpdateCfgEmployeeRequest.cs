using MediatR;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.CfgEmployee.UpdateCfgEmployee;

public sealed record UpdateCfgEmployeeRequest : IRequest<bool>
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string CertificationNumber { get; init; }
    public required string EmployeeNumber { get; init; }
    public EmployeeRole Role { get; init; }
    public bool IsActive { get; init; }
}
