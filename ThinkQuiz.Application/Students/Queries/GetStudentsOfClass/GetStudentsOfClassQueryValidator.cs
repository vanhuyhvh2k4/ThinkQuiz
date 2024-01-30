using FluentValidation;

namespace ThinkQuiz.Application.Students.Queries.GetStudentsOfClass
{
    public class GetStudentsOfClassQueryValidator : AbstractValidator<GetStudentsOfClassQuery>
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

            When(c => c.SortBy.HasValue, () =>
            {
                RuleFor(c => c.SortBy)
                .Must(c => c == SortBy.FullName || c == SortBy.Email)
                .WithMessage("Allow to sort by field: 'Name' or 'StudentQuantity'");

                RuleFor(c => c.OrderBy)
                    .Must(c => c == OrderBy.Asc || c == OrderBy.Desc)
                    .WithMessage("Allow to order by 'Asc' or 'Desc'");
            });
        }
	}
}

