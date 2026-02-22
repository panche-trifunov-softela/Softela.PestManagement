using Softela.PestManagement.Domain.Entities;

namespace Softela.PestManagement.Application.Queries.FeatureFlag.GetFeatures;

public sealed record GetFeaturesResponse
{
    public List<TenantFeature> Data { get; init; }
}
