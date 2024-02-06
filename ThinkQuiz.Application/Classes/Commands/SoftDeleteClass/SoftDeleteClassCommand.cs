using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Application.Classes.Commands.SoftDeleteClass
{
	public record SoftDeleteClassCommand(Guid TeacherId, Guid ClassId) : IRequest<ErrorOr<Class>>;
}

