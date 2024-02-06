using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkQuiz.Application.Students.Queries.ExportStudentsList;
using ThinkQuiz.Application.Students.Queries.GetStudentsOfClass;
using ThinkQuiz.Contracts.Students.GetStudentsOfClass;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    public class StudentController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public StudentController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Policy = "Teacher")]
        [HttpGet("students/class/{classId}")]
        public async Task<IActionResult> GetStudentsOfClass([FromRoute] Guid classId, [FromQuery] GetStudentsOfClassRequest request)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var query = _mapper.Map<GetStudentsOfClassQuery>((teacherId, classId, request));

            var getStudentsResults = await _mediator.Send(query);

            return getStudentsResults.Match(
                getStudentsResult => Ok(_mapper.Map<GetStudentsOfClassResponse>(getStudentsResult)),
                errors => Problem(errors));
        }

        [Authorize(Policy = "Teacher")]
        [HttpGet("students/class/{classId}/export")]
        public async Task<IActionResult> ExportStudentList(Guid classId)
        {
            Guid teacherId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "teacherId")!.Value);

            var query = _mapper.Map<ExportStudentsListQuery>((teacherId, classId));

            var exportStudentsResults = await _mediator.Send(query);

            return exportStudentsResults.Match(
                exportStudentsResult => File(exportStudentsResult.Content, exportStudentsResult.ContentType, exportStudentsResult.FileName),
                errors => Problem(errors));
        }
    }
}

