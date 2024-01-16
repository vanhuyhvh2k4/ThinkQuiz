using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Contracts.Authentication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("/v1/api/")]
    public class AuthenticationController : Controller
    {
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(request);
        }
    }
}

