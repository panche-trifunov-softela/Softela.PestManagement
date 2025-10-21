using MediatR;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Account.CreateAccount;
using Softela.PestManagement.Application.Commands.Account.UpdateAccount;
using Softela.PestManagement.Application.Queries.Account.GetAccountById;
using Softela.PestManagement.Application.Queries.Account.GetAccounts;

namespace Softela.PestManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IMediator mediator, ILogger<AccountsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Get all accounts for a company with optional search and filtering
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAccounts(
            [FromQuery] int companyId,
            [FromQuery] string? searchTerm = null,
            [FromQuery] short? isActive = null)
        {
            try
            {
                var request = new GetAccountsRequest
                {
                    CompanyId = companyId,
                    SearchTerm = searchTerm,
                    IsActive = isActive
                };

                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accounts for company {CompanyId}", companyId);
                return StatusCode(500, "An error occurred while retrieving accounts");
            }
        }

        /// <summary>
        /// Get a specific account by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            try
            {
                var request = new GetAccountByIdRequest { Id = id };
                var response = await _mediator.Send(request);

                if (response.Account == null)
                {
                    return NotFound($"Account with ID {id} not found");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving account {AccountId}", id);
                return StatusCode(500, "An error occurred while retrieving the account");
            }
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
        {
            try
            {
                var accountId = await _mediator.Send(request);
                return CreatedAtAction(nameof(GetAccountById), new { id = accountId }, new { id = accountId });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Validation error while creating account");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating account");
                return StatusCode(500, "An error occurred while creating the account");
            }
        }

        /// <summary>
        /// Update an existing account
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateAccountRequest request)
        {
            try
            {
                if (id != request.Id)
                {
                    return BadRequest("ID in URL does not match ID in request body");
                }

                var success = await _mediator.Send(request);
                if (success)
                {
                    return NoContent();
                }

                return StatusCode(500, "Update failed");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Validation error while updating account {AccountId}", id);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating account {AccountId}", id);
                return StatusCode(500, "An error occurred while updating the account");
            }
        }
    }
}
