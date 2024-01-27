﻿using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ClassStudentExceptions = ThinkQuiz.Domain.Common.Exceptions.ClassStudent.Exceptions;
using StudentExceptions = ThinkQuiz.Domain.Common.Exceptions.Student.Exceptions;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;

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

        public async Task<ErrorOr<AddStudentResult>> Handle(AddStudentCommand query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // check classStudent exists
            if (_classStudentRepository.Get(query.StudentId, query.ClassId) is not null)
            {
                return ClassStudentExceptions.DuplicateClassStudent;
            }
            // check student exsist
            if (_studentRepository.GetStudentById(query.StudentId) is null)
            {
                return StudentExceptions.NotFoundStudent;
            }

            // check class exist
            if (_classRepository.GetClassById(query.ClassId) is null)
            {
                return ClassExceptions.NotFoundClass;
            }

            var classStudent = ClassStudent.Create(query.StudentId, query.ClassId);

            _classStudentRepository.Add(classStudent);

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

