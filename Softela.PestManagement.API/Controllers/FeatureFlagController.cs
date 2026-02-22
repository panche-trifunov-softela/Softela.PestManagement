using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Core.FeatureFlags;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Core.Tenant;
using Softela.PestManagement.Application.Queries.FeatureFlag.GetFeatures;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/feature-flags")]
public class FeatureFlagController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly IFeatureFlagService _featureFlagService;
    private readonly ITenantContext _tenantContext;

    public FeatureFlagController(
        IQueryDispatcher queryDispatcher,
        IFeatureFlagService featureFlagService,
        ITenantContext tenantContext)
    {
        _queryDispatcher = queryDispatcher;
        _featureFlagService = featureFlagService;
        _tenantContext = tenantContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetFeatures(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetFeaturesRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> CheckFeature(string key)
    {
        var isEnabled = await _featureFlagService.IsEnabledAsync(_tenantContext.TenantId, key);
        return Ok(new { key, isEnabled });
    }
}
