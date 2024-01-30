using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using StudentAggregate = ThinkQuiz.Domain.StudentAggregate.Student;

namespace ThinkQuiz.Application.Students.Queries.GetStudentsOfClass
{
    public class GetStudentsOfClassQueryHandler : IRequestHandler<GetStudentOfClassQuery, ErrorOr<List<StudentAggregate>>>
	{
        private readonly IStudentRepository _studentRepository;

        public GetStudentsOfClassQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<ErrorOr<List<StudentAggregate>>> Handle(GetStudentOfClassQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

