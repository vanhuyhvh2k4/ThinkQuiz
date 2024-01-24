using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
    public interface ITeacherRepository
	{
		void Add(Teacher teacher);

		Teacher? GetTeacherByUserId(Guid userId);
	}
}

