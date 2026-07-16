using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployees;

public sealed record GetCfgEmployeesRequest : IRequest<GetCfgEmployeesResponse>;
