using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IUserRepository
	{
		User? GetUserByEmail(string email);

		User? GetUserById(Guid id);

		void Add(User user);

		void UpdateUser(User user);
	}
}

