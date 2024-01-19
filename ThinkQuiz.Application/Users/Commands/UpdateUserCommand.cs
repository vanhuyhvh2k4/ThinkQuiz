using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Users.Commands
{
    public record UpdateUserCommand(
        Guid UserId,
        string? FullName,
        DateOnly? DateOfBirth,
        string? Phone,
        bool? Gender) : IRequest<ErrorOr<User>>;
	
}

