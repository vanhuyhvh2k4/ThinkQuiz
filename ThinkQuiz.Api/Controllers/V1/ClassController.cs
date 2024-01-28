using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Application.Class.Commands.AddStudent;
using ThinkQuiz.Application.Class.Commands.Create;
using ThinkQuiz.Application.Class.Commands.JoinClass;
using ThinkQuiz.Application.Class.Queries.GetClass;
using ThinkQuiz.Application.Class.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.AddStudent;
using ThinkQuiz.Contracts.Class.Create;
using ThinkQuiz.Contracts.Class.GetClass;
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

        [Authorize]
        [HttpGet("classes/teacher/{teacherId}")]
        public async Task<IActionResult> GetClassesOfTeacher([FromQuery] GetClassesRequest request, [FromRoute] Guid teacherId)
        {
            var query = _mapper.Map<GetClassesQuery>((request, teacherId));

            var getClassesResult = await _mediator.Send(query);

            return getClassesResult.Match(
               getClassesResult => Ok(_mapper.Map<GetClassesResponse>(getClassesResult)),
               errors => Problem(errors)
               );
        }

        [Authorize]
        [HttpGet("classes/{classId}")]
        public async Task<IActionResult> GetClassById(Guid classId)
        {
            var query = new GetClassQuery(classId);

            var getClassResult = await _mediator.Send(query);

            return getClassResult.Match(
               classResult => Ok(_mapper.Map<GetClassResponse>(classResult)),
               errors => Problem(errors)
               );
        }

        [Authorize(Policy = "Teacher")]
        [HttpPost("classes")]
        public async Task<IActionResult> Create(CreateClassRequest request)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var command = _mapper.Map<CreateClassCommand>((teacherId, request));

            var createClassResults = await _mediator.Send(command);

            return createClassResults.Match(
               createClassResult => StatusCode(StatusCodes.Status201Created, _mapper.Map<CreateClassResponse>(createClassResult)),
               errors => Problem(errors)
               );
        }

        [Authorize(Policy = "Teacher")]
        [HttpPost("classes/add_student")]
        public async Task<IActionResult> AddStudentToClass(AddStudentRequest request)
        {
            var command = _mapper.Map<AddStudentCommand>(request);

            var addStudentResults = await _mediator.Send(command);

            return addStudentResults.Match(
              addStudentResult => StatusCode(StatusCodes.Status201Created, _mapper.Map<AddStudentResponse>(addStudentResult)),
              errors => Problem(errors)
              );
        }

        [Authorize(Policy = "Student")]
        [HttpPost("classes/join_class/{classId}")]
        public async Task<IActionResult> JoinClass([FromRoute] Guid classId)
        {
            Guid studentId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "studentId")!.Value);

            var command = _mapper.Map<JoinClassCommand>((studentId, classId));

            var joinClassResults = await _mediator.Send(command);

            return joinClassResults.Match(
              joinClassResult => StatusCode(StatusCodes.Status201Created, _mapper.Map<AddStudentResponse>(joinClassResult)),
              errors => Problem(errors)
              );
        }
    }
}

