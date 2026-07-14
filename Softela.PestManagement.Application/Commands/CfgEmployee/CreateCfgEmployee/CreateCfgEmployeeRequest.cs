using MediatR;
using Softela.PestManagement.Domain.Enums;

namespace Softela.PestManagement.Application.Commands.CfgEmployee.CreateCfgEmployee;

public sealed record CreateCfgEmployeeRequest : IRequest<int>
{
    public required string Name { get; init; }
    public required string CertificationNumber { get; init; }
    public required string EmployeeNumber { get; init; }
    public EmployeeRole Role { get; init; }
    public bool IsActive { get; init; }
}
