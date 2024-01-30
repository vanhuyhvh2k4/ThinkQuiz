using ThinkQuiz.Domain.ClassAggregate;
namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IClassRepository
	{
		void Create(Class newClass);

		List<Class> GetClassesByTeacherId(Guid teacherId);

		Class? GetClassById(Guid classId);
	}
}

