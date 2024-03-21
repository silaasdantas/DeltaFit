using DeltaFit.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeltaFit.Api.Abstractions;
using DeltaFit.Application.Abstractions.Authentication;
using DeltaFit.Application.Login;

namespace DeltaFit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ApiController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtProvider _jwtProvider;

        public AuthController(
            ILogger<AuthController> logger,
            IJwtProvider jwtProvider)
        {
            _logger = logger;
            _jwtProvider = jwtProvider;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<Jwt> Authenticate([FromBody] LoginCommand command)
        {
            _logger.LogInformation("Generating JTW token");

            var token = _jwtProvider.GenerateToken(command);

            return Ok(token);
        }
    }
}
