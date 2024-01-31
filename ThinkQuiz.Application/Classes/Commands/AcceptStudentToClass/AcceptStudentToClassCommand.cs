using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Application.Classes.Commands.AcceptStudentToClass
{
    public record AcceptStudentToClassCommand(Guid TeacherId, Guid StudentId, Guid ClassId) : IRequest<ErrorOr<ClassStudent>>;
}

