using ErrorOr;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    [ApiController]
    [Route("/v1/api/")]
    [ApiVersion("1.0")]
    public class ApiController : Controller
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                Problem();
            }

            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }
    }
}

