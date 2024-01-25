using System;
using ThinkQuiz.Domain.StudeæntAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
	public interface IStudentRepository
	{
		void Add(Student student);

		Student? GetStudentByUserId(Guid userId);
	}
}

