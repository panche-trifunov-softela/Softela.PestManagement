using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgEmployeeRepository
{
    Task<int> CreateAsync(CfgEmployee cfgEmployee);
    Task<int> UpdateAsync(CfgEmployee cfgEmployee);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgEmployee?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgEmployee>> GetByTenantIdAsync(int tenantId);
}
