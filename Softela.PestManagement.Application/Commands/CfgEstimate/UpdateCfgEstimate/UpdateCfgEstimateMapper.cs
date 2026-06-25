namespace Softela.PestManagement.Application.Commands.CfgEstimate.UpdateCfgEstimate;

public static class UpdateCfgEstimateMapper
{
    public static Domain.Entities.CfgEstimate ToDomainEntity(UpdateCfgEstimateRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgEstimate
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}
