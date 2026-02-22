using Softela.PestManagement.Application.Core.FeatureFlags;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Infrastructure.Core.FeatureFlags;

public class FeatureFlagService : IFeatureFlagService
{
    private readonly ITenantFeatureRepository _featureRepository;

    public FeatureFlagService(ITenantFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<bool> IsEnabledAsync(int tenantId, string key)
    {
        return await _featureRepository.IsEnabledAsync(tenantId, key);
    }

    public async Task<List<TenantFeature>> GetFeaturesAsync(int tenantId)
    {
        return await _featureRepository.GetByTenantIdAsync(tenantId);
    }
}
