using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimates;

public sealed record GetCfgEstimatesResponse
{
    public required List<CfgEstimateDto> Data { get; init; }
}
