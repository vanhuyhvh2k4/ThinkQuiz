using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Application.Classes.Commands.Create
{
    public record CreateClassCommand(Guid teacherId, string Name, string SchoolYear) : IRequest<ErrorOr<Class>>;
}

