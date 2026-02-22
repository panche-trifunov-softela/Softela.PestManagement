namespace Softela.PestManagement.Domain.Entities;

public class TenantFeature
{
    public int Id { get; set; }
    public int TenantId { get; set; }
    public string FeatureKey { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
