using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Class.Common;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Class;

namespace ThinkQuiz.Application.Class.Queries.GetClasses
{
    public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, ErrorOr<List<ClassResult>>>
	{
        private readonly IClassRepository _classRepository;

        public GetClassesQueryHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<List<ClassResult>>> Handle(GetClassesQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // 1. get all classes of teacher
            var classes = _classRepository.GetClassByTeacherId(query.TeacherId);
            var classResults = new List<ClassResult>();

            // Find class by name
            if (!string.IsNullOrEmpty(query.Name))
            {
                classes = classes.FindAll(c => c.Name.ToLower().Contains(query.Name.ToLower().Trim()));
            }

            if (classes.Count is 0)
            {
                return Exceptions.NotFoundClass;
            }

            // 2. pagination classes
            if (query.Page.HasValue && query.PerPage.HasValue)
            {
                int? startIndex = (query.Page - 1) * query.PerPage;
                int? endIndex = startIndex + query.PerPage;

                if (startIndex < 0 || startIndex >= classes.Count || query.Page <= 0)
                    return classResults;
                if (endIndex > classes.Count)
                    endIndex = classes.Count;

                classes = classes.GetRange(startIndex.Value, endIndex.Value - startIndex.Value);
            }

            // 3. sort classes

            if (query.SortBy.HasValue)
            {
                if (query.OrderBy.Equals(OrderBy.Desc))
                {
                    classes = classes.OrderByDescending(x => x.GetType().GetProperty(query.SortBy.Value.ToString())!.GetValue(x)).ToList();
                }
                else
                {
                    classes = classes.OrderBy(x => x.GetType().GetProperty(query.SortBy.Value.ToString())!.GetValue(x)).ToList();
                }
            };

            foreach (var item in classes)
            {
                var classResult = new ClassResult(
                    Id: item.Id.ToString(),
                    TeacherId: item.TeacherId.ToString(),
                    Name: item.Name,
                    SchoolYear: item.SchoolYear,
                    StudentQuantity: item.StudentQuantity,
                    CreatedAt: item.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdatedAt: item.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")
                    );

                classResults.Add(classResult);
            }

            return classResults;
        }
    }
}

