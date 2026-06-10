using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Program.CreateProgram;
using Softela.PestManagement.Application.Commands.Program.DeleteProgram;
using Softela.PestManagement.Application.Commands.Program.UpdateProgram;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.Program.GetProgramById;
using Softela.PestManagement.Application.Queries.Program.GetPrograms;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/programs")]
public class ProgramController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ProgramController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetPrograms([FromQuery] int estimateId, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetProgramsRequest { EstimateId = estimateId }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgramById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetProgramByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgram([FromBody] CreateProgramRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateProgramRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProgram(int id, [FromBody] UpdateProgramRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateProgramRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgram(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteProgramRequest>(
            new DeleteProgramRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
