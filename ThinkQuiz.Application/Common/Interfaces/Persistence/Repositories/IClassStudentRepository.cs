using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IClassStudentRepository
	{
		void Add(ClassStudent classStudent);

		ClassStudent? Get(Guid studentId, Guid classId);

		void Remove(ClassStudent classStudent);
	}
}

