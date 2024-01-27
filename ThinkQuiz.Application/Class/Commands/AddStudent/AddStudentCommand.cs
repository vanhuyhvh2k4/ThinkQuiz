using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Class.Common;

namespace ThinkQuiz.Application.Class.Commands.AddStudent
{
    public record AddStudentCommand(Guid StudentId, Guid ClassId) : IRequest<ErrorOr<AddStudentResult>>;
}

