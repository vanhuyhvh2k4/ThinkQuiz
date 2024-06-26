﻿using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IStudentRepository
	{
		void Add(Student student);

		Student? GetStudentByUserId(Guid userId);

		Student? GetStudentById(Guid studentId);

		List<Student> GetStudentsByClassId(Guid classId, bool status = true);
	}
}

