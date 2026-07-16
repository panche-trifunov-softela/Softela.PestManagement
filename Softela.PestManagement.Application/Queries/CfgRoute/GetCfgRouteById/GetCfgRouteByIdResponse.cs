using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRouteById;

public sealed record GetCfgRouteByIdResponse
{
    public required CfgRouteDto Data { get; init; }
}
