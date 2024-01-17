using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories
{
    public interface IUserRepository
	{
		User? GetUserByEmail(string email);

		void Add(User user);
	}
}

