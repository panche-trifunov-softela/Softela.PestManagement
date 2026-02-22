using MediatR;
using Softela.PestManagement.Application.Core.FeatureFlags;
using Softela.PestManagement.Application.Core.Tenant;

namespace Softela.PestManagement.Application.Queries.FeatureFlag.GetFeatures;

public class GetFeaturesHandler : IRequestHandler<GetFeaturesRequest, GetFeaturesResponse>
{
    private readonly IFeatureFlagService _featureFlagService;
    private readonly ITenantContext _tenantContext;

    public GetFeaturesHandler(IFeatureFlagService featureFlagService, ITenantContext tenantContext)
    {
        _featureFlagService = featureFlagService;
        _tenantContext = tenantContext;
    }

    public async Task<GetFeaturesResponse> Handle(GetFeaturesRequest request, CancellationToken cancellationToken)
    {
        var features = await _featureFlagService.GetFeaturesAsync(_tenantContext.TenantId);
        return new GetFeaturesResponse { Data = features };
    }
}
