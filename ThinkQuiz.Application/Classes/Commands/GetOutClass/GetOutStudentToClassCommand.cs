using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Application.Classes.Commands.GetOutClass
{
    public record GetOutStudentToClassCommand(Guid TeacherId, Guid StudentId, Guid ClassId) : IRequest<ErrorOr<ClassStudent>>;

}

