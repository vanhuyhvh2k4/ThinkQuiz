using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Authentication.Common;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FullName,
        string Password,
        string Email,
        string ConfirmPassword,
        RegisterType RegisterType,
        string? Position,
        string? SchoolInformation) : IRequest<ErrorOr<AuthenticationResult>>;

    public enum RegisterType
    {
        Student = 0,
        Teacher = 1
    }
}

