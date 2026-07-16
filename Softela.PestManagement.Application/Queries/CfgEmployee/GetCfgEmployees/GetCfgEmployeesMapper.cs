using Softela.PestManagement.Application.Dtos;

namespace Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployees;

public static class GetCfgEmployeesMapper
{
    public static CfgEmployeeDto ToDto(Domain.Entities.CfgEmployee cfgEmployee)
    {
        return new CfgEmployeeDto
        {
            Id = cfgEmployee.Id,
            Name = cfgEmployee.Name,
            CertificationNumber = cfgEmployee.CertificationNumber,
            EmployeeNumber = cfgEmployee.EmployeeNumber,
            Role = cfgEmployee.Role,
            IsActive = cfgEmployee.IsActive,
            CreatedAt = cfgEmployee.CreatedAt,
            ModifiedAt = cfgEmployee.ModifiedAt
        };
    }
}
