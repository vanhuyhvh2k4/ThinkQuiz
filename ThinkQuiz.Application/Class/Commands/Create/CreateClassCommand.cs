using ErrorOr;
using MediatR;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Application.Class.Commands.Create
{
    public record CreateClassCommand(Guid teacherId, string Name, string SchoolYear) : IRequest<ErrorOr<ClassAggregate>>;
}

