using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Application.Classes.Queries.GetClass
{
    public record GetClassQuery(Guid ClassId) : IRequest<ErrorOr<Class>>;
}

