using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Application.Class.Commands.AddStudent
{
    public record AddStudentCommand(Guid StudentId, Guid ClassId) : IRequest<ErrorOr<ClassStudent>>;
}

