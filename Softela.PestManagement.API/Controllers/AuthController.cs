using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softela.PestManagement.Application.Commands.User;
using Softela.PestManagement.Application.Queries.Auth.GetToken;

namespace Softela.PestManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;
    
        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("create-user", Name = "CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _mediator.Send(request);

            if (result)
            {
                return Ok(new { Message = "User created successfully." });
            }

            return BadRequest(new { Message = "Failed to create user." });
        }

        [HttpPost("token", Name = "GetToken")]
        public async Task<IActionResult> GetToken([FromBody] GetTokenRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(new
                {
                    response.AccessToken,
                    Message = "Token generated successfully."
                });
            }

            return Unauthorized(new { Message = "Invalid username or password." });
        }
    }
}
