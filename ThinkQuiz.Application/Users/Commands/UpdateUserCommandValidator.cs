using FluentValidation;
using ThinkQuiz.Application.Common.Validator.DateTimeValidator;
using ThinkQuiz.Application.Common.Validator.BasicInforValidator;

namespace ThinkQuiz.Application.Users.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            When(u => u.FullName is not null, () =>
            {
                RuleFor(u => u.FullName)
                    .NotEmpty()
                    .MaximumLength(100);
            });

            When(u => u.DateOfBirth is not null, () =>
            {
                RuleFor(u => u.DateOfBirth)
                    .NotEmpty()
                    .Must(date => DateTimeValidators.BeLessThanCurrentDay(date!.Value))
                    .WithMessage("DateOfBirth must be less than the current date.");
            });

            When(u => u.Gender is not null, () =>
            {
                RuleFor(u => u.Gender)
                    .NotEmpty();
            });

            When(u => u.Phone is not null, () =>
            {
                RuleFor(u => u.Phone)
                    .NotEmpty()
                    .Must(phone => BasicInforValidators.BePhone(phone!))
                    .WithMessage("Phone must be correct phone format.")
                    .MaximumLength(10);
            });
        }
    }
}

