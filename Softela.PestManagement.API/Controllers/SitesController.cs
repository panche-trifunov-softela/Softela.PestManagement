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
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSites([FromQuery] GetSitesRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sites");
                return StatusCode(500, "An error occurred while retrieving sites");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSiteById(int id)
        {
            try
            {
                var request = new GetSiteByIdRequest { Id = id };
                var response = await _mediator.Send(request);

                if (response.Data == null)
                {
                    return NotFound($"Site with ID {id} not found");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving site {SiteId}", id);
                return StatusCode(500, "An error occurred while retrieving the site");
            }
        }

        [HttpPost]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSite(int id, [FromBody] UpdateSiteRequest request)
        {
            try
            {
                request.Id = id;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite(int id)
        {
            try
            {
                var request = new DeleteSiteRequest { Id = id };
                var success = await _mediator.Send(request);

                if (success)
                {
                    return NoContent();
                }

                return StatusCode(500, "Delete failed");
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Validation error while deleting site {SiteId}", id);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting site {SiteId}", id);
                return StatusCode(500, "An error occurred while deleting the site");
            }
        }
    }
}
