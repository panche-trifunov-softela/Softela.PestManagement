using MediatR;

namespace Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRouteById;

public sealed record GetCfgRouteByIdRequest : IRequest<GetCfgRouteByIdResponse>
{
    public int Id { get; init; }
}
