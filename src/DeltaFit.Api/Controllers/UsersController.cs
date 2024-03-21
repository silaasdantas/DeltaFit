using DeltaFit.Api.Abstractions;
using DeltaFit.Api.Contracts.Users;
using DeltaFit.Application.Services;
using DeltaFit.Application.Users.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFit.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        //[HasPermission(Permission.Read)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _userService.GetUserByIdQuery(id, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(
               request.Email,
               request.Phone,
               request.FirstName,
               request.LastName,
               request.Password);

            var result = await _userService.CreateUser(command, cancellationToken);

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = result.Value },
                result.Value);
        }


        [HttpGet]
        [Route("open")]
        [Authorize]
        public IActionResult GetEmployeee()
        {
            return Ok("Hi " + User.Identity.Name + " this route is open to all.");
        }

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "Admin,Trainer")]
        public IActionResult GetManager()
        {
            return Ok("Logged in as Admin, Trainer: " + User.Identity.Name);
        }


        [HttpGet]
        [Route("student")]
        [Authorize(Roles = "Student")]
        public IActionResult GetDirector()
        {
            return Ok("Logged in as Student: " + User.Identity.Name);
        }
    }
}
