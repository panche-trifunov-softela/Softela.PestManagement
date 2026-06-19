using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.Estimate.GetEstimates;

public static class GetEstimatesMapper
{
    public static EstimateDto ToDto(Domain.Entities.OpsEstimate estimate)
    {
        return new EstimateDto
        {
            Id = estimate.Id,
            ServiceAddressId = estimate.ServiceAddressId,
            CfgEstimateId = estimate.CfgEstimateId,
            Status = estimate.Status,
            ServiceInterest = estimate.ServiceInterest,
            AssignedSalesRep = estimate.AssignedSalesRep,
            Source = estimate.Source,
            CreatedAt = estimate.CreatedAt,
            ModifiedAt = estimate.ModifiedAt
        };
    }
}
