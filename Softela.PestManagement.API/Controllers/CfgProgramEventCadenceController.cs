using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.CfgProgramEventCadence.CreateCfgProgramEventCadence;
using Softela.PestManagement.Application.Commands.CfgProgramEventCadence.DeleteCfgProgramEventCadence;
using Softela.PestManagement.Application.Commands.CfgProgramEventCadence.UpdateCfgProgramEventCadence;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadenceById;
using Softela.PestManagement.Application.Queries.CfgProgramEventCadence.GetCfgProgramEventCadences;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/cfg-program-event-cadences")]
public class CfgProgramEventCadenceController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CfgProgramEventCadenceController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCfgProgramEventCadences([FromQuery] int cfgProgramId, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgProgramEventCadencesRequest { CfgProgramId = cfgProgramId }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCfgProgramEventCadenceById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgProgramEventCadenceByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCfgProgramEventCadence([FromBody] CreateCfgProgramEventCadenceRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCfgProgramEventCadenceRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCfgProgramEventCadence(int id, [FromBody] UpdateCfgProgramEventCadenceRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCfgProgramEventCadenceRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCfgProgramEventCadence(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCfgProgramEventCadenceRequest>(
            new DeleteCfgProgramEventCadenceRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
