using ErrorOr;
using MediatR;
using StudentAggregate = ThinkQuiz.Domain.StudentAggregate.Student;

namespace ThinkQuiz.Application.Students.Queries.GetStudentsOfClass
{
	public record GetStudentOfClassQuery(
        Guid ClassId,
        int? Page,
        int? PerPage) : IRequest<ErrorOr<List<StudentAggregate>>>;
}

