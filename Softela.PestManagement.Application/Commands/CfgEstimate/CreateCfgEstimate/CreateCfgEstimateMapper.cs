namespace Softela.PestManagement.Application.Commands.CfgEstimate.CreateCfgEstimate;

public static class CreateCfgEstimateMapper
{
    public static Domain.Entities.CfgEstimate ToDomainEntity(CreateCfgEstimateRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgEstimate
        {
            Name = request.Name,
            Description = request.Description,
            TenantId = tenantId,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };
    }
}
