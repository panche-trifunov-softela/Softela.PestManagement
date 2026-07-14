using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRoutes;

public sealed record GetCfgRoutesResponse
{
    public required List<CfgRouteDto> Data { get; init; }
}
