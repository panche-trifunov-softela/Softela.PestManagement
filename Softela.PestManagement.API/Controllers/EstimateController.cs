using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Estimate.CreateEstimate;
using Softela.PestManagement.Application.Commands.Estimate.DeleteEstimate;
using Softela.PestManagement.Application.Commands.Estimate.UpdateEstimate;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.Estimate.GetEstimates;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/estimates")]
public class EstimateController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public EstimateController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetEstimates([FromQuery] int serviceAddressId, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetEstimatesRequest { ServiceAddressId = serviceAddressId }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEstimate([FromBody] CreateEstimateRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateEstimateRequest>(request, cancellationToken);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEstimate(int id, [FromBody] UpdateEstimateRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateEstimateRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEstimate(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteEstimateRequest>(
            new DeleteEstimateRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
