using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;
using StudentExceptions = ThinkQuiz.Domain.Common.Exceptions.Student.Exceptions;
using ClassStudentExceptions = ThinkQuiz.Domain.Common.Exceptions.ClassStudent.Exceptions;

namespace ThinkQuiz.Application.Classes.Commands.AcceptStudentToClass
{
    public class AcceptStudentToClassCommandHandler : IRequestHandler<AcceptStudentToClassCommand, ErrorOr<ClassStudent>>
	{
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassStudentRepository _classStudentRepository;

        public AcceptStudentToClassCommandHandler(IClassRepository classRepository, IStudentRepository studentRepository, IClassStudentRepository classStudentRepository)
        {
            _classRepository = classRepository;
            _studentRepository = studentRepository;
            _classStudentRepository = classStudentRepository;
        }

        public async Task<ErrorOr<ClassStudent>> Handle(AcceptStudentToClassCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // check class exists
            if (_classRepository.GetClassById(request.ClassId) is not Class @class)
            {
                return ClassExceptions.NotFoundClass;
            }

            // check teacher owns class
            if (@class.TeacherId != request.TeacherId)
            {
                return ClassStudentExceptions.NotPermissionToAcceptStudent;
            }

            // check student exists
            if (_studentRepository.GetStudentById(request.StudentId) is null)
            {
                return StudentExceptions.NotFoundStudent;
            }

            // check is student in class
            if (_classStudentRepository.Get(request.StudentId, request.ClassId) is not ClassStudent classStudent)
            {
                return ClassStudentExceptions.NotFoundStudentInClass;
            }

            // check status
            if (classStudent.Status == true)
            {
                return ClassStudentExceptions.DuplicateClassStudent;
            }

            // accept student to class
            classStudent.UpdateStatus(true);

            // update student quantity of class
            @class.AddStudentQuantity();

            // persist db
            _classStudentRepository.Update(classStudent);
            _classRepository.Update(@class);

            return classStudent;
        }
    }
}

