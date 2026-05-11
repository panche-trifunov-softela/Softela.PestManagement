using MediatR;

namespace Softela.PestManagement.Application.Commands.Estimate.DeleteEstimate;

public sealed record DeleteEstimateRequest : IRequest<bool>
{
    public int Id { get; init; }
}
