using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Application.Authentication.Commands.Register;
using ThinkQuiz.Contracts.Authentication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("/v1/api/")]
    public class AuthenticationController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public AuthenticationController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            var registerResult = await _sender.Send(command);

            return registerResult.Match(
               registerResult => Ok(_mapper.Map<AuthenticationResponse>(registerResult)),
               errors => Problem(errors)
               );
        }
    }
}

