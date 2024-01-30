using FluentValidation;

namespace ThinkQuiz.Application.Classes.Commands.Create
{
    public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
	{
		public CreateClassCommandValidator()
		{
			RuleFor(c => c.teacherId)
				.NotEmpty();

			RuleFor(c => c.Name)
				.NotEmpty()
				.MaximumLength(100);

			RuleFor(c => c.SchoolYear)
				.NotEmpty();
		}
	}
}

