using ErrorOr;
using MediatR;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Application.Class.Queries.GetClass
{
    public record GetClassQuery(Guid ClassId) : IRequest<ErrorOr<ClassAggregate>>;
}

