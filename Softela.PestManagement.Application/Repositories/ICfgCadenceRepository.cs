using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgCadenceRepository
{
    Task<int> CreateAsync(CfgCadence cfgCadence);
    Task<int> UpdateAsync(CfgCadence cfgCadence);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgCadence?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgCadence>> GetByTenantIdAsync(int tenantId);
}
