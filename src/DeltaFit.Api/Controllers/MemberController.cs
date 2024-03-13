using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DeltaFit.Api.Abstractions;

namespace DeltaFit.Api.Controllers
{
    public class MemberController : ApiController
    {
        private readonly ILogger<MemberController> _logger;
        
        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/open")]
        [Authorize]
        public IActionResult GetEmployeee()
        {
            return Ok("Hi " + User.Identity.Name + " this route is open to all.");
        }

        [HttpGet]
        [Route("/manager")]
        [Authorize(Roles = "Admin,Trainer")]
        public IActionResult GetManager()
        {
            return Ok("Logged in as Admin, Trainer: " + User.Identity.Name);
        }


        [HttpGet]
        [Route("/student")]
        [Authorize(Roles = "Student")]
        public IActionResult GetDirector()
        {
            return Ok("Logged in as Student: " + User.Identity.Name);
        }
    }
}
