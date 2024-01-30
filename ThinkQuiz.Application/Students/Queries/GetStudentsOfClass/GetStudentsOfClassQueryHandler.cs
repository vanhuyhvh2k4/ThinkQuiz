using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using StudentExceptions = ThinkQuiz.Domain.Common.Exceptions.Student.Exceptions;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;
using ThinkQuiz.Application.Common.Utils;

namespace ThinkQuiz.Application.Students.Queries.GetStudentsOfClass
{
    public class GetStudentsOfClassQueryHandler : IRequestHandler<GetStudentsOfClassQuery, ErrorOr<List<Student>>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public GetStudentsOfClassQueryHandler(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<List<Student>>> Handle(GetStudentsOfClassQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check class exist
            if (_classRepository.GetClassById(query.ClassId) is not Class @class)
            {
                return ClassExceptions.NotFoundClass;
            }

            // check teacher owners class
            if (@class.TeacherId != query.TeacherId)
            {
                return StudentExceptions.NotPermissionToGetStudents;
            }

            // Get all students of class by classid and status
            var students = _studentRepository.GetStudentsByClassId(query.ClassId, query.Status);

            if (students.Count == 0)
            {
                return StudentExceptions.NotFoundStudent;
            }

            // Find student by fullname or email
            if (!string.IsNullOrEmpty(query.FullName) || !string.IsNullOrEmpty(query.Email))
            {
                students = students.FindAll(student =>
                {
                    bool fullNameMatch = !string.IsNullOrEmpty(query.FullName) && student.User.FullName.Contains(query.FullName);
                    bool emailMatch = !string.IsNullOrEmpty(query.Email) && student.User.Email.Contains(query.Email);
                    return fullNameMatch || emailMatch;
                });
            }

            // pagination classes
            if (query.Page.HasValue && query.PerPage.HasValue)
            {
                students = PaginationUtility.PaginateList(students, query.Page.Value, query.PerPage.Value);
            }

            // sort students
            if (query.SortBy.HasValue)
            {
                if (query.OrderBy.Equals(OrderBy.Desc))
                {
                    students = students.OrderByDescending(x => x.GetType()
                                                                .GetProperty("User")!
                                                                .GetValue(x)!
                                                                .GetType()
                                                                .GetProperty(query.SortBy.Value.ToString())!
                                                                .GetValue(x.User))
                                                    .ToList();
                }
                else
                {
                    students = students.OrderBy(x => x.GetType()
                                                      .GetProperty("User")!
                                                      .GetValue(x)!
                                                      .GetType()
                                                      .GetProperty(query.SortBy.Value.ToString())!
                                                      .GetValue(x.User))
                                                    .ToList();
                }
            };

            return students;
        }
    }
}

