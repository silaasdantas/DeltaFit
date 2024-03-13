using DeltaFit.Api.Abstractions;
using DeltaFit.Api.Application.Members.Commands;
using DeltaFit.Api.Application.Members.Commands.CreateMember;
using DeltaFit.Api.Application.Members.Commands.Login;
using DeltaFit.Api.Application.Members.Queries;
using DeltaFit.Api.Application.Members.Queries.GetMemberById;
using DeltaFit.Api.Application.Members.Queries.GetMembers;
using DeltaFit.Api.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace DeltaFit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ApiController
    {
        private readonly ILogger<MembersController> _logger;

        public MembersController(ISender sender, ILogger<MembersController> logger)
              : base(sender)
        {
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginMember(
            [FromBody] LoginRequest request,
            CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.Email, request.Password);

            Result<string> tokenResult = await Sender.Send(
                command,
                cancellationToken);

            if (tokenResult.IsFailure)
            {
                return BadRequest();
                //return HandleFailure(tokenResult);
            }

            return Ok(tokenResult.Value);

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterMember(
           [FromBody] RegisterMemberRequest request,
           CancellationToken cancellationToken)
        {
            var command = new CreateMemberCommand(
                request.Email,
                request.Phone,
                request.FirstName,
                request.LastName,
                request.Password);

            Result<Guid> result = await Sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result);
                //return HandleFailure(tokenResult);
            }

            return CreatedAtAction(
              nameof(GetMemberById),
              new { id = result.Value },
              result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMemberById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetMemberByIdQuery(id);

            Result<MemberResponse> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers(int page, int pageSize, CancellationToken cancellationToken)
        {
            _logger.LogInformation("INICIO::MembersController::Request para o método GetMembers");

            var query = new GetMembersQuery(page, pageSize);

            Result<List<MemberResponse>> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
