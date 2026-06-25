namespace Softela.PestManagement.Application.Commands.CfgEvent.UpdateCfgEvent;

public static class UpdateCfgEventMapper
{
    public static Domain.Entities.CfgEvent ToDomainEntity(UpdateCfgEventRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgEvent
        {
            Id = request.Id,
            Name = request.Name,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}
