using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRoutes;

public sealed record GetCfgRoutesRequest : IRequest<GetCfgRoutesResponse>
{
    public int CfgEmployeeId { get; init; }
}
