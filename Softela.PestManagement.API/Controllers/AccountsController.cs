using MediatR;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Account.CreateAccount;
using Softela.PestManagement.Application.Commands.Account.DeleteAccount;
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
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all accounts with optional filtering
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(GetAccountsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAccounts([FromQuery] int companyId, [FromQuery] string? searchTerm, [FromQuery] short? isActive)
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

        /// <summary>
        /// Get account by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetAccountByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var request = new GetAccountByIdRequest { Id = id };
            var response = await _mediator.Send(request);

            if (response?.Data == null)
            {
                return NotFound(new { message = $"Account with ID {id} not found." });
            }

            return Ok(response);
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateAccountRequest request)
        {
            try
            {
                request.Id = id; // Set ID from route parameter

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

        /// <summary>
        /// Delete an account (soft delete)
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var request = new DeleteAccountRequest { Id = id };
            var success = await _mediator.Send(request);

            if (!success)
            {
                return NotFound(new { message = $"Account with ID {id} not found." });
            }

            return Ok(new { message = "Account deleted successfully." });
        }
    }
}
