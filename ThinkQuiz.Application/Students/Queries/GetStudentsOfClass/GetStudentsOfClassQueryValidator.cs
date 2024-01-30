using FluentValidation;

namespace ThinkQuiz.Application.Students.Queries.GetStudentsOfClass
{
    public class GetStudentsOfClassQueryValidator : AbstractValidator<GetStudentOfClassQuery>
	{
		public GetStudentsOfClassQueryValidator()
		{
            When(s => s.Page.HasValue || s.PerPage.HasValue, () =>
            {
                RuleFor(s => s.Page)
                    .NotNull()
                    .WithMessage("You have to provide 'page'")
                    .GreaterThan(0);

                RuleFor(s => s.PerPage)
                    .NotNull()
                    .WithMessage("You have to provide 'perPage'")
                    .GreaterThan(0);
            });
        }
	}
}

