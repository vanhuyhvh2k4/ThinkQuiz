﻿using FluentValidation;
using ThinkQuiz.Application.Common.Validator.BasicInforValidator;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
	{
		public RegisterCommandValidator()
		{
			RuleFor(r => r.FullName)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(r => r.Email)
				.NotEmpty()
				.EmailAddress()
				.MaximumLength(100);

			RuleFor(r => r.Password)
				.NotEmpty()
				.Must(password => BasicInforValidators.BePassword(password))
				.WithMessage("Password must contain letters, numbers, and special characters")
				.MinimumLength(6)
				.MaximumLength(50);

			RuleFor(r => r.ConfirmPassword)
				.Equal(r => r.Password)
				.WithMessage("Confirm password must equal password");
		}
	}
}

