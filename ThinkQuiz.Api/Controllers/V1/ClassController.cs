using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Application.Classes.Commands.AcceptStudentToClass;
using ThinkQuiz.Application.Classes.Commands.AddStudent;
using ThinkQuiz.Application.Classes.Commands.Create;
using ThinkQuiz.Application.Classes.Commands.GetOutStudentToClass;
using ThinkQuiz.Application.Classes.Commands.JoinClass;
using ThinkQuiz.Application.Classes.Commands.SoftDeleteClass;
using ThinkQuiz.Application.Classes.Queries.GetClass;
using ThinkQuiz.Application.Classes.Queries.GetClasses;
using ThinkQuiz.Contracts.Class.AcceptStudent;
using ThinkQuiz.Contracts.Class.AddStudent;
using ThinkQuiz.Contracts.Class.Create;
using ThinkQuiz.Contracts.Class.GetClass;
using ThinkQuiz.Contracts.Class.GetClasses;
using ThinkQuiz.Contracts.Class.GetOutStudent;
using ThinkQuiz.Contracts.Common;

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
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var command = _mapper.Map<AddStudentCommand>((teacherId, request));

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

        [Authorize(Policy = "Teacher")]
        [HttpDelete("classes/get_out")]
        public async Task<IActionResult> GetOutStudentToClass(GetOutStudentRequest request)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var command = _mapper.Map<GetOutStudentToClassCommand>((teacherId, request));

            var getOutResults = await _mediator.Send(command);

            return getOutResults.Match(
                getOutResult => Ok(new DeleteResponse()),
                errors => Problem(errors));
        }

        [Authorize(Policy = "Teacher")]
        [HttpPatch("classes/accept_student")]
        public async Task<IActionResult> AcceptStudentToClass(GetOutStudentRequest request)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var command = _mapper.Map<AcceptStudentToClassCommand>((teacherId, request));

            var acceptResults = await _mediator.Send(command);

            return acceptResults.Match(
                acceptResult => Ok(_mapper.Map<AcceptStudentResponse>(acceptResult)),
                errors => Problem(errors));
        }

        [Authorize(Policy = "Teacher")]
        [HttpDelete("classes/{classId}")]
        public async Task<IActionResult> SoftDeleteClass(Guid classId)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var command = _mapper.Map<SoftDeleteClassCommand>((teacherId, classId));

            var softDeleteClassResults = await _mediator.Send(command);

            return softDeleteClassResults.Match(
                softDeleteClassResult => Ok(new DeleteResponse()),
                errors => Problem(errors));
        }
    }
}

