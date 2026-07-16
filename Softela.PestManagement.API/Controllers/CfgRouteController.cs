using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.CfgRoute.CreateCfgRoute;
using Softela.PestManagement.Application.Commands.CfgRoute.DeleteCfgRoute;
using Softela.PestManagement.Application.Commands.CfgRoute.UpdateCfgRoute;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRouteById;
using Softela.PestManagement.Application.Queries.CfgRoute.GetCfgRoutes;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/cfg-routes")]
public class CfgRouteController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CfgRouteController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCfgRoutes([FromQuery] int cfgEmployeeId, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgRoutesRequest { CfgEmployeeId = cfgEmployeeId }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCfgRouteById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgRouteByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCfgRoute([FromBody] CreateCfgRouteRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCfgRouteRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCfgRoute(int id, [FromBody] UpdateCfgRouteRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCfgRouteRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCfgRoute(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCfgRouteRequest>(
            new DeleteCfgRouteRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
