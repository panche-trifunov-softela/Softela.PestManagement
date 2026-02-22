using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Tenant.CreateTenant;
using Softela.PestManagement.Application.Commands.Tenant.UpdateTenant;
using Softela.PestManagement.Application.Commands.Tenant.UpsertFeature;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.Tenant.GetTenantById;
using Softela.PestManagement.Application.Queries.Tenant.GetTenants;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize(Roles = "admin")]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public AdminController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("tenants")]
    public async Task<IActionResult> GetTenants(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetTenantsRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("tenants/{id}")]
    public async Task<IActionResult> GetTenantById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetTenantByIdRequest { Id = id }, cancellationToken);
        if (result.Data == null)
            return NotFound();
        return Ok(result.Data);
    }

    [HttpPost("tenants")]
    public async Task<IActionResult> CreateTenant([FromBody] CreateTenantRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateTenantRequest>(request, cancellationToken);
        return CreatedAtAction(nameof(GetTenantById), new { id }, new { id });
    }

    [HttpPut("tenants/{id}")]
    public async Task<IActionResult> UpdateTenant(int id, [FromBody] UpdateTenantRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateTenantRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpPut("tenants/{id}/features")]
    public async Task<IActionResult> UpsertFeature(int id, [FromBody] UpsertFeatureRequest request, CancellationToken cancellationToken)
    {
        var command = request with { TenantId = id };
        var result = await _commandDispatcher.SendAsync<bool, UpsertFeatureRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpGet("tenants/{id}/features")]
    public async Task<IActionResult> GetFeatures(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new Application.Queries.FeatureFlag.GetFeatures.GetFeaturesRequest(), cancellationToken);
        return Ok(result.Data);
    }
}
