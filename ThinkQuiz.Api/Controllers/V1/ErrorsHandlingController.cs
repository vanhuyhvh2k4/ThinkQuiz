using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    public class ErrorsHandlingController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}

