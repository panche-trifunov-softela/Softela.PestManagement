using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgRoute.DeleteCfgRoute;

public sealed record DeleteCfgRouteRequest : IRequest<bool>
{
    public int Id { get; init; }
}
