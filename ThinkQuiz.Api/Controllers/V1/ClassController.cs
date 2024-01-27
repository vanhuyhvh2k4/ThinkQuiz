using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Application.Class.Commands.Create;
using ThinkQuiz.Application.Class.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.Create;
using ThinkQuiz.Contracts.Class.GetClasses;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    public class ClassController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ClassController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Policy = "Teacher")]
        [HttpGet("classes")]
        public async Task<IActionResult> GetClasses([FromQuery] GetClassesRequest request)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var query = _mapper.Map<GetClassesQuery>((teacherId, request));

            var getClassesResult = await _mediator.Send(query);

            return getClassesResult.Match(
               getClassesResult => Ok(_mapper.Map<GetClassesResponse>(getClassesResult)),
               errors => Problem(errors)
               );
        }

        [Authorize(Policy = "Teacher")]
        [HttpPost("classes")]
        public async Task<IActionResult> Create(CreateClassRequest request)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var command = _mapper.Map<CreateClassCommand>((teacherId, request));

            var createClassResult = await _mediator.Send(command);

            return createClassResult.Match(
               createClassResult => StatusCode(StatusCodes.Status201Created, _mapper.Map<CreateClassResponse>(createClassResult)),
               errors => Problem(errors)
               );
        }
    }
}

