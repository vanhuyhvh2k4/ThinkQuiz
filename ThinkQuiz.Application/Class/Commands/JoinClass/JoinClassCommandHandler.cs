using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.Common.Exceptions.Class;
using ClassStudentExceptions = ThinkQuiz.Domain.Common.Exceptions.ClassStudent.Exceptions;

namespace ThinkQuiz.Application.Class.Commands.JoinClass
{
    public class JoinClassCommandHandler : IRequestHandler<JoinClassCommand, ErrorOr<ClassStudent>>
	{
        private readonly IClassStudentRepository _classStudentRepository;
        private readonly IClassRepository _classRepository;

        public JoinClassCommandHandler(IClassStudentRepository classStudentRepository, IClassRepository classRepository)
        {
            _classStudentRepository = classStudentRepository;
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<ClassStudent>> Handle(JoinClassCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check classStudent exists
            if (_classStudentRepository.Get(command.StudentId, command.ClassId) is not null)
            {
                return ClassStudentExceptions.DuplicateClassStudent;
            }

            // check class exists
            if (_classRepository.GetClassById(command.ClassId) is null)
            {
                return Exceptions.NotFoundClass;
            }

            var classStudent = ClassStudent.Create(command.StudentId, command.ClassId);

            _classStudentRepository.Add(classStudent);

            return classStudent;
        }
    }
}

