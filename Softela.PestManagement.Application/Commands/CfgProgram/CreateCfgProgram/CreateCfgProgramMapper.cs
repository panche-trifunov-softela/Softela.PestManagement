namespace Softela.PestManagement.Application.Commands.CfgProgram.CreateCfgProgram;

public static class CreateCfgProgramMapper
{
    public static Domain.Entities.CfgProgram ToDomainEntity(CreateCfgProgramRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgProgram
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
