using ErrorOr;
using MediatR;

namespace ThinkQuiz.Application.Class.Commands.AddStudent
{
    public record AddStudentCommand(Guid StudentId, Guid ClassId) : IRequest<ErrorOr<AddStudentResult>>;
}

