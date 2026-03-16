using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Core.FeatureFlags;

public interface IFeatureFlagService
{
    Task<bool> IsEnabledAsync(int tenantId, string key);
    Task<List<TenantFeature>> GetFeaturesAsync(int tenantId);
}
