namespace Softela.PestManagement.Application.Commands.CfgProgram.UpdateCfgProgram;

public static class UpdateCfgProgramMapper
{
    public static Domain.Entities.CfgProgram ToDomainEntity(UpdateCfgProgramRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgProgram
        {
            Id = request.Id,
            Name = request.Name,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}
