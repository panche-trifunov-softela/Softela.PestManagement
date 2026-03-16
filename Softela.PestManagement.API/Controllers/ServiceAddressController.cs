using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.ServiceAddress.CreateServiceAddress;
using Softela.PestManagement.Application.Commands.ServiceAddress.DeleteServiceAddress;
using Softela.PestManagement.Application.Commands.ServiceAddress.UpdateServiceAddress;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddressById;
using Softela.PestManagement.Application.Queries.ServiceAddress.GetServiceAddresses;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/service-addresses")]
public class ServiceAddressController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ServiceAddressController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetServiceAddresses([FromQuery] int customerId, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetServiceAddressesRequest { CustomerId = customerId }, cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetServiceAddressById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(
            new GetServiceAddressByIdRequest { Id = id }, cancellationToken);
        if (result.Data == null)
            return NotFound();
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateServiceAddress([FromBody] CreateServiceAddressRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateServiceAddressRequest>(request, cancellationToken);
        return CreatedAtAction(nameof(GetServiceAddressById), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServiceAddress(int id, [FromBody] UpdateServiceAddressRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateServiceAddressRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceAddress(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteServiceAddressRequest>(
            new DeleteServiceAddressRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
