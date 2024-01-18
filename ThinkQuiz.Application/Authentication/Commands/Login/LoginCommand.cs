using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;

namespace ThinkQuiz.Application.Authentication.Commands.Login
{
    public record LoginCommand(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}

