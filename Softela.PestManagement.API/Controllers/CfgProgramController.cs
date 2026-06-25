using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.CfgProgram.CreateCfgProgram;
using Softela.PestManagement.Application.Commands.CfgProgram.DeleteCfgProgram;
using Softela.PestManagement.Application.Commands.CfgProgram.UpdateCfgProgram;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.CfgProgram.GetCfgProgramById;
using Softela.PestManagement.Application.Queries.CfgProgram.GetCfgPrograms;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/cfg-programs")]
public class CfgProgramController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CfgProgramController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCfgPrograms(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetCfgProgramsRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCfgProgramById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgProgramByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCfgProgram([FromBody] CreateCfgProgramRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCfgProgramRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCfgProgram(int id, [FromBody] UpdateCfgProgramRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCfgProgramRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCfgProgram(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCfgProgramRequest>(
            new DeleteCfgProgramRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
