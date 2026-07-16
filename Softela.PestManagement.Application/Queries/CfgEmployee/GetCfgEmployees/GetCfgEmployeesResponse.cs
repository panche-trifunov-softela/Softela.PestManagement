using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployees;

public sealed record GetCfgEmployeesResponse
{
    public required List<CfgEmployeeDto> Data { get; init; }
}
