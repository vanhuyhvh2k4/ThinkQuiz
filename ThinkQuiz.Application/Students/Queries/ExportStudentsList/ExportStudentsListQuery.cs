using ErrorOr;
using MediatR;

namespace ThinkQuiz.Application.Students.Queries.ExportStudentsList
{
    public record ExportStudentsListQuery(Guid TeacherId, Guid ClassId) : IRequest<ErrorOr<ExportStudentsListResult>>;
}

