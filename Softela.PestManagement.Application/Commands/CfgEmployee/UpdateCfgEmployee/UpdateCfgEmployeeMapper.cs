namespace Softela.PestManagement.Application.Commands.CfgEmployee.UpdateCfgEmployee;

public static class UpdateCfgEmployeeMapper
{
    public static Domain.Entities.CfgEmployee ToDomainEntity(UpdateCfgEmployeeRequest request, DateTimeOffset now, Guid userId, int tenantId)
    {
        return new Domain.Entities.CfgEmployee
        {
            Id = request.Id,
            Name = request.Name,
            CertificationNumber = request.CertificationNumber,
            EmployeeNumber = request.EmployeeNumber,
            Role = request.Role,
            IsActive = request.IsActive,
            TenantId = tenantId,
            ModifiedAt = now,
            ModifiedBy = userId
        };
    }
}
