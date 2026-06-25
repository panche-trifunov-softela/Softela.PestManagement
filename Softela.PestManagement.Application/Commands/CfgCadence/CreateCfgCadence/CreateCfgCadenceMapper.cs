namespace Softela.PestManagement.Application.Commands.CfgCadence.CreateCfgCadence;

public static class CreateCfgCadenceMapper
{
    public static Domain.Entities.CfgCadence ToDomainEntity(CreateCfgCadenceRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgCadence
        {
            Name = request.Name,
            TenantId = tenantId,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };
    }
}
