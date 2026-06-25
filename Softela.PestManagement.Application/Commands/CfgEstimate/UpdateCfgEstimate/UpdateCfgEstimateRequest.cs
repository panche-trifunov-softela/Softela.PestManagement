using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEstimate.UpdateCfgEstimate;

public sealed record UpdateCfgEstimateRequest : IRequest<bool>
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
}
