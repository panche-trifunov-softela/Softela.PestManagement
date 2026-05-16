namespace Softela.PestManagement.Domain.Entities;

public class TenantFeature : TenantScopedEntity
{
    public string FeatureKey { get; set; }
    public bool IsEnabled { get; set; }
}
