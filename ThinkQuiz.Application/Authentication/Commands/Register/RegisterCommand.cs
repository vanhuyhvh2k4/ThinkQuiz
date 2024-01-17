using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FullName,
        string Password,
        string Email,
        string ConfirmPassword) : IRequest<ErrorOr<AuthenticationResult>>;
}

