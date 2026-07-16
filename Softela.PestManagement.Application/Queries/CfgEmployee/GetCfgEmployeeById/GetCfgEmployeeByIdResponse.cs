using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployeeById;

public sealed record GetCfgEmployeeByIdResponse
{
    public required CfgEmployeeDto Data { get; init; }
}
