using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Application.Classes.Commands.AddStudent
{
    public record AddStudentCommand(Guid TeacherId, Guid StudentId, Guid ClassId) : IRequest<ErrorOr<ClassStudent>>;
}

