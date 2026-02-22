using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Repositories;

public interface ITenantFeatureRepository
{
    Task UpsertAsync(TenantFeature feature);
    Task<List<TenantFeature>> GetByTenantIdAsync(int tenantId);
    Task<bool> IsEnabledAsync(int tenantId, string key);
}
