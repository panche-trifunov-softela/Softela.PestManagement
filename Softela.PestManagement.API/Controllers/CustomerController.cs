using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Customer.CreateCustomer;
using Softela.PestManagement.Application.Commands.Customer.DeleteCustomer;
using Softela.PestManagement.Application.Commands.Customer.UpdateCustomer;
using Softela.PestManagement.Application.Core.Command;
using Softela.PestManagement.Application.Core.Query;
using Softela.PestManagement.Application.Queries.Customer.GetCustomerById;
using Softela.PestManagement.Application.Queries.Customer.GetCustomers;

namespace Softela.PestManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CustomerController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetCustomersRequest(), cancellationToken);
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.QueryAsync(new GetCustomerByIdRequest { Id = id }, cancellationToken);
        if (result.Data == null)
            return NotFound();
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var id = await _commandDispatcher.SendAsync<int, CreateCustomerRequest>(request, cancellationToken);
        return CreatedAtAction(nameof(GetCustomerById), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var command = request with { Id = id };
        var result = await _commandDispatcher.SendAsync<bool, UpdateCustomerRequest>(command, cancellationToken);
        return Ok(new { success = result });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
    {
        var result = await _commandDispatcher.SendAsync<bool, DeleteCustomerRequest>(
            new DeleteCustomerRequest { Id = id }, cancellationToken);
        return Ok(new { success = result });
    }
}
