using MediatR;

namespace Softela.PestManagement.Application.Queries.Estimate.GetEstimates;

public sealed record GetEstimatesRequest : IRequest<GetEstimatesResponse>
{
    public int ServiceAddressId { get; init; }
}
