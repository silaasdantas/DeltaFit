using DeltaFit.Api.Abstractions;
using DeltaFit.Application.Users.Commands;
using DeltaFit.Domain.Entities;
using DeltaFit.Infrastructure.Abstractions.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFit.Api.Controllers
{
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
        public ActionResult<Jwt> LoginUser([FromBody] LoginCommand command)
        {
            _logger.LogInformation("Generating JTW token");

            //TODO: verificar se o usuario existe
            var user = new User();

            var token = _jwtProvider.GenerateToken(user);

            return Ok(token);
        }
    }
}
