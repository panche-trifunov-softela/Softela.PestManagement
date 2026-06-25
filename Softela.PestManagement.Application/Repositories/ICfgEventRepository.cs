using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgEventRepository
{
    Task<int> CreateAsync(CfgEvent cfgEvent);
    Task<int> UpdateAsync(CfgEvent cfgEvent);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgEvent?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgEvent>> GetByTenantIdAsync(int tenantId);
}
