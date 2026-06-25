namespace Softela.PestManagement.Application.Commands.CfgProgramEventCadence.CreateCfgProgramEventCadence;

public static class CreateCfgProgramEventCadenceMapper
{
    public static Domain.Entities.CfgProgramEventCadence ToDomainEntity(CreateCfgProgramEventCadenceRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgProgramEventCadence
        {
            CfgProgramId = request.CfgProgramId,
            CfgEventId = request.CfgEventId,
            CfgCadenceId = request.CfgCadenceId,
            Interval = request.Interval,
            TenantId = tenantId,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };
    }
}
