using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.CfgCadence.CreateCfgCadence;
using Softela.PestManagement.Application.Commands.CfgCadence.DeleteCfgCadence;
using Softela.PestManagement.Application.Commands.CfgCadence.UpdateCfgCadence;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadenceById;
using Softela.PestManagement.Application.Queries.CfgCadence.GetCfgCadences;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/cfg-cadences")]
public class CfgCadenceController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CfgCadenceController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCfgCadences(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetCfgCadencesRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCfgCadenceById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgCadenceByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCfgCadence([FromBody] CreateCfgCadenceRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCfgCadenceRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCfgCadence(int id, [FromBody] UpdateCfgCadenceRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCfgCadenceRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCfgCadence(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCfgCadenceRequest>(
            new DeleteCfgCadenceRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
