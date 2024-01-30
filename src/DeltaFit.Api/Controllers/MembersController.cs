using DeltaFit.Api.Abstractions;
using DeltaFit.Api.Application.Members.Queries;
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

        [HttpGet()]
        public async Task<IActionResult> GetMembers(int page, int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetMembersQuery(page, pageSize);

            Result<List<MemberResponse>> response = await Sender.Send(query, cancellationToken);

            return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
        }
    }
}
