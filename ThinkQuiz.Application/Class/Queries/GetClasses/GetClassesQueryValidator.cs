using System;
using FluentValidation;

namespace ThinkQuiz.Application.Class.Queries.GetClasses
{
    public class GetClassesQueryValidator : AbstractValidator<GetClassesQuery>
    {
        public GetClassesQueryValidator()
        {
            When(c => !string.IsNullOrEmpty(c.Name), () =>
            {
                RuleFor(c => c.Name)
                    .MaximumLength(50);
            });

            When(c => c.Page.HasValue || c.PerPage.HasValue, () =>
            {
                RuleFor(c => c.Page)
                    .NotNull()
                    .WithMessage("You have to provide 'page'")
                    .GreaterThan(0);

                RuleFor(c => c.PerPage)
                    .NotNull()
                    .WithMessage("You have to provide 'perPage'")
                    .GreaterThan(0);
            });

            When(c => c.SortBy.HasValue, () =>
                {
                    RuleFor(c => c.SortBy)
                    .Must(c => c == SortBy.Name || c == SortBy.StudentQuantity)
                    .WithMessage("Allow to sort by field: 'Name' or 'StudentQuantity'");

                    RuleFor(c => c.OrderBy)
                        .Must(c => c == OrderBy.Asc || c == OrderBy.Desc)
                        .WithMessage("Allow to order by 'Asc' or 'Desc'");
            }); 
        }
    }
}

