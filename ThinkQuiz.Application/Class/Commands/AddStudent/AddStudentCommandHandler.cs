using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ClassStudentExceptions = ThinkQuiz.Domain.Common.Exceptions.ClassStudent.Exceptions;
using StudentExceptions = ThinkQuiz.Domain.Common.Exceptions.Student.Exceptions;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;
using ThinkQuiz.Application.Class.Common;
using ClassAggregate = ThinkQuiz.Domain.ClassAggregate.Class;

namespace ThinkQuiz.Application.Class.Commands.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, ErrorOr<AddStudentResult>>
	{
        private readonly IClassStudentRepository _classStudentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public AddStudentCommandHandler(IClassStudentRepository classStudentRepository, IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _classStudentRepository = classStudentRepository;
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<AddStudentResult>> Handle(AddStudentCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check classStudent exists
            if (_classStudentRepository.Get(command.StudentId, command.ClassId) is not null)
            {
                return ClassStudentExceptions.DuplicateClassStudent;
            }
            // check student exsist
            if (_studentRepository.GetStudentById(command.StudentId) is null)
            {
                return StudentExceptions.NotFoundStudent;
            }

            // check class exist
            if (_classRepository.GetClassById(command.ClassId) is not ClassAggregate @class)
            {
                return ClassExceptions.NotFoundClass;
            }

            // create new classStudent
            var classStudent = ClassStudent.Create(command.StudentId, command.ClassId, true);

            // update student quantity
            @class.AddStudentQuantity();

            // persist db
            _classStudentRepository.Add(classStudent);

            // mapping and return
            var addStudentResult = new AddStudentResult(
                classStudent.StudentId.ToString(),
                classStudent.ClassId.ToString(),
                classStudent.Status,
                classStudent.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                classStudent.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")); ;

            return addStudentResult;
        }
    }
}

