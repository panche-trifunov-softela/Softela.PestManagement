namespace Softela.PestManagement.Application.Commands.CfgEmployee.CreateCfgEmployee;

public static class CreateCfgEmployeeMapper
{
    public static Domain.Entities.CfgEmployee ToDomainEntity(CreateCfgEmployeeRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgEmployee
        {
            Name = request.Name,
            CertificationNumber = request.CertificationNumber,
            EmployeeNumber = request.EmployeeNumber,
            Role = request.Role,
            IsActive = request.IsActive,
            TenantId = tenantId,
            CreatedAt = now,
            ModifiedAt = now,
            CreatedBy = userId,
            ModifiedBy = userId
        };
    }
}
