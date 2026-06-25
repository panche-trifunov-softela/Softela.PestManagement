namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.UpdateCfgProgramEventCadence;

public static class UpdateCfgProgramEventCadenceMapper
{
    public static Domain.Entities.CfgProgramEventCadence ToDomainEntity(UpdateCfgProgramEventCadenceRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgProgramEventCadence
        {
            Id = request.Id,
            CfgProgramId = request.CfgProgramId,
            CfgEventId = request.CfgEventId,
            CfgCadenceId = request.CfgCadenceId,
            Interval = request.Interval,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}
