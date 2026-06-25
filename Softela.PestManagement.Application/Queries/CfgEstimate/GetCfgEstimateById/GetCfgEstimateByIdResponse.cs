using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimateById;

public sealed record GetCfgEstimateByIdResponse
{
    public required CfgEstimateDto Data { get; init; }
}
