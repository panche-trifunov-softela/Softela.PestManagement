using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgRoute.CreateCfgRoute;

public sealed record CreateCfgRouteRequest : IRequest<int>
{
    public int CfgEmployeeId { get; init; }
    public required string Name { get; init; }
    public bool IsActive { get; init; }
    public string? Note { get; init; }
}
