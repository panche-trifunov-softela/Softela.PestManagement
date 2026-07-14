using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgRoute.UpdateCfgRoute;

public sealed record UpdateCfgRouteRequest : IRequest<bool>
{
    public int Id { get; init; }
    public int CfgEmployeeId { get; init; }
    public required string Name { get; init; }
    public bool IsActive { get; init; }
    public string? Note { get; init; }
}
