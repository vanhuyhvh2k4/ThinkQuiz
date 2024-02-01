using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.Common.Exceptions.Class;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Application.Common.Utils;
using TeacherExceptions = ThinkQuiz.Domain.Common.Exceptions.Teacher.Exceptions;

namespace ThinkQuiz.Application.Classes.Queries.GetClasses
{
    public class GetClassesQueryHandler : IRequestHandler<GetClassesQuery, ErrorOr<List<Class>>>
	{
        private readonly IClassRepository _classRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetClassesQueryHandler(IClassRepository classRepository, ITeacherRepository teacherRepository)
        {
            _classRepository = classRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<ErrorOr<List<Class>>> Handle(GetClassesQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check teacher exists
            if (_teacherRepository.GetTeacherById(query.TeacherId) is null)
            {
                return TeacherExceptions.NotFoundTeacher;
            }

            // 1. get all classes of teacher
            var classes = _classRepository.GetClassesByTeacherId(query.TeacherId);

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
                classes = PaginationUtility.PaginateList(classes, query.Page.Value, query.PerPage.Value);
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

            return classes;
        }
    }
}

