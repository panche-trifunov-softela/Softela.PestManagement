using MediatR;

namespace Softela.PestManagement.Application.Commands.CfgEstimate.DeleteCfgEstimate;

public sealed record DeleteCfgEstimateRequest : IRequest<bool>
{
    public int Id { get; init; }
}
