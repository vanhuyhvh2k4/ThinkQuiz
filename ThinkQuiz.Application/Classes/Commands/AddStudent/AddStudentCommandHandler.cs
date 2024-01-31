using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ClassStudentExceptions = ThinkQuiz.Domain.Common.Exceptions.ClassStudent.Exceptions;
using StudentExceptions = ThinkQuiz.Domain.Common.Exceptions.Student.Exceptions;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Application.Classes.Commands.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, ErrorOr<ClassStudent>>
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

        public async Task<ErrorOr<ClassStudent>> Handle(AddStudentCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check student exsist
            if (_studentRepository.GetStudentById(command.StudentId) is null)
            {
                return StudentExceptions.NotFoundStudent;
            }

            // check class exist
            if (_classRepository.GetClassById(command.ClassId) is not Class @class)
            {
                return ClassExceptions.NotFoundClass;
            }

            // check permisstion of teacherid
            if (@class.TeacherId != command.TeacherId)
            {
                return ClassStudentExceptions.NotPermissionToAddStudent;
            }

            // check classStudent exists
            if (_classStudentRepository.Get(command.StudentId, command.ClassId) is not null)
            {
                return ClassStudentExceptions.DuplicateClassStudent;
            }

            // create new classStudent
            var classStudent = ClassStudent.Create(
                command.StudentId,
                command.ClassId,
                true);

            // update student quantity
            @class.AddStudentQuantity();

            // persist db
            _classStudentRepository.Add(classStudent);
            _classRepository.Update(@class);

            return classStudent;
        }
    }
}

