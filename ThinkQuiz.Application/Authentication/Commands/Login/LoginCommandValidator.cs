using System;
using FluentValidation;

namespace ThinkQuiz.Application.Authentication.Commands.Login
{
	public class LoginCommandValidator : AbstractValidator<LoginCommand>
	{
		public LoginCommandValidator()
		{
			RuleFor(l => l.Email)
				.EmailAddress()
				.NotEmpty();

			RuleFor(l => l.Password)
				.NotEmpty();
		}
	}
}

