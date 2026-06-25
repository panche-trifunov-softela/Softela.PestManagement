using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ICfgEstimateRepository
{
    Task<int> CreateAsync(CfgEstimate cfgEstimate);
    Task<int> UpdateAsync(CfgEstimate cfgEstimate);
    Task DeleteAsync(int id, int tenantId, DateTimeOffset modifiedAt, Guid modifiedBy);
    Task<CfgEstimate?> GetByIdAsync(int id, int tenantId);
    Task<List<CfgEstimate>> GetByTenantIdAsync(int tenantId);
}
