using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.CfgEmployee.CreateCfgEmployee;
using Softela.PestManagement.Application.Commands.CfgEmployee.DeleteCfgEmployee;
using Softela.PestManagement.Application.Commands.CfgEmployee.UpdateCfgEmployee;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployeeById;
using Softela.PestManagement.Application.Queries.CfgEmployee.GetCfgEmployees;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/cfg-employees")]
public class CfgEmployeeController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CfgEmployeeController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCfgEmployees(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetCfgEmployeesRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCfgEmployeeById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetCfgEmployeeByIdRequest { Id = id }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCfgEmployee([FromBody] CreateCfgEmployeeRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCfgEmployeeRequest>(request, cancellationToken);
        return Created(string.Empty, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCfgEmployee(int id, [FromBody] UpdateCfgEmployeeRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCfgEmployeeRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCfgEmployee(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCfgEmployeeRequest>(
            new DeleteCfgEmployeeRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
