using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEstimate.CreateCfgEstimate;

public sealed record CreateCfgEstimateRequest : IRequest<int>
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
