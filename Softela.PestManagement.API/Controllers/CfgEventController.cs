using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.CfgEvent.CreateCfgEvent;
using Softela.PestManagement.Application.Commands.CfgEvent.DeleteCfgEvent;
using Softela.PestManagement.Application.Commands.CfgEvent.UpdateCfgEvent;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEventById;
using Softela.PestManagement.Application.Queries.CfgEvent.GetCfgEvents;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/cfg-events")]
public class CfgEventController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CfgEventController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCfgEvents(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetCfgEventsRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCfgEventById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgEventByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCfgEvent([FromBody] CreateCfgEventRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCfgEventRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCfgEvent(int id, [FromBody] UpdateCfgEventRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCfgEventRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCfgEvent(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCfgEventRequest>(
            new DeleteCfgEventRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
