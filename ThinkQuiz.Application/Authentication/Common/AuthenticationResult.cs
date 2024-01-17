using System;
namespace ThinkQuiz.Application.Authentication.Common
{
	public record AuthenticationResult(
        string fullName,
        string Email,
        string dateOfBirth,
        string Phone,
        DateTime LastLogin,
        bool Gender,
        string Token);
}

