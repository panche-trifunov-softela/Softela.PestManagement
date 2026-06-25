using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEstimate.GetCfgEstimateById;

public static class GetCfgEstimateByIdMapper
{
    public static CfgEstimateDto ToDto(Domain.Entities.CfgEstimate cfgEstimate)
    {
        return new CfgEstimateDto
        {
            Id = cfgEstimate.Id,
            Name = cfgEstimate.Name,
            Description = cfgEstimate.Description,
            CreatedAt = cfgEstimate.CreatedAt,
            ModifiedAt = cfgEstimate.ModifiedAt
        };
    }
}
