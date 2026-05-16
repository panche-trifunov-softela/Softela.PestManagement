using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.Estimate.GetEstimates;

public sealed record GetEstimatesResponse
{
    public List<EstimateDto> Data { get; init; }
}
