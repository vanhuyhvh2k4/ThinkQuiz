using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Class.Common;

namespace ThinkQuiz.Application.Class.Queries.GetClass
{
    public record GetClassQuery(Guid ClassId) : IRequest<ErrorOr<ClassResult>>;
}

