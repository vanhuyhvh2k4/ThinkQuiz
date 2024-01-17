using FluentValidation;

namespace ThinkQuiz.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
	{
		public RegisterCommandValidator()
		{
			RuleFor(r => r.FullName).NotEmpty();
			RuleFor(r => r.Email)
				.NotEmpty()
				.EmailAddress();
			RuleFor(r => r.Password)
				.NotEmpty()
				.Matches("^(?=.*[a-zA-Z])(?=.*\\d)(?=.*[^\\w\\s]).+$")
				.WithMessage("Password must contain letters, numbers, and special characters")
				.MinimumLength(6);
			RuleFor(r => r.ConfirmPassword)
				.Equal(r => r.Password)
				.WithMessage("Confirm password must equal password");
		}
	}
}

