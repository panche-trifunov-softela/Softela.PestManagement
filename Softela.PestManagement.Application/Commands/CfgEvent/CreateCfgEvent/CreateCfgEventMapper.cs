namespace Softela.PestManagement.Application.Commands.CfgEvent.CreateCfgEvent;

public static class CreateCfgEventMapper
{
    public static Domain.Entities.CfgEvent ToDomainEntity(CreateCfgEventRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgEvent
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
