using MediatR;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.Site.CreateSite;
using Softela.PestManagement.Application.Commands.Site.DeleteSite;
using Softela.PestManagement.Application.Commands.Site.UpdateSite;
using Softela.PestManagement.Application.Queries.Site.GetSiteById;
using Softela.PestManagement.Application.Queries.Site.GetSites;

namespace Softela.PestManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SitesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SitesController> _logger;

        public SitesController(IMediator mediator, ILogger<SitesController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all sites, optionally filtered by account
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(GetSitesResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSites([FromQuery] int? accountId)
        {
            var request = new GetSitesRequest
            {
                AccountId = accountId
            };

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Get site by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetSiteByIdResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSiteById(int id)
        {
            var request = new GetSiteByIdRequest { Id = id };
            var response = await _mediator.Send(request);

            if (response?.Data == null)
            {
                return NotFound(new { message = $"Site with ID {id} not found." });
            }

            return Ok(response);
        }

        /// <summary>
        /// Create a new site
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSite([FromBody] CreateSiteRequest request)
        {
            try
            {
                var siteId = await _mediator.Send(request);
                return CreatedAtAction(nameof(GetSiteById), new { id = siteId }, new { id = siteId });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Validation error while creating site");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating site");
                return StatusCode(500, "An error occurred while creating the site");
            }
        }

        /// <summary>
        /// Update an existing site
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSite(int id, [FromBody] UpdateSiteRequest request)
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
                _logger.LogWarning(ex, "Validation error while updating site {SiteId}", id);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating site {SiteId}", id);
                return StatusCode(500, "An error occurred while updating the site");
            }
        }

        /// <summary>
        /// Delete a site (soft delete)
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSite(int id)
        {
            var request = new DeleteSiteRequest { Id = id };
            var success = await _mediator.Send(request);

            if (!success)
            {
                return NotFound(new { message = $"Site with ID {id} not found." });
            }

            return Ok(new { message = "Site deleted successfully." });
        }
    }
}
