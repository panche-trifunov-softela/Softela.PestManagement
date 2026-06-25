namespace Softela.PestManagement.Application.Commands.CfgCadence.UpdateCfgCadence;

public static class UpdateCfgCadenceMapper
{
    public static Domain.Entities.CfgCadence ToDomainEntity(UpdateCfgCadenceRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgCadence
        {
            Id = request.Id,
            Name = request.Name,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}
