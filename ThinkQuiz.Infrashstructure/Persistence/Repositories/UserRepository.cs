using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
	{
        private readonly ThinkQuizDbContext _context;

        public UserRepository(ThinkQuizDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.AsEnumerable().SingleOrDefault(u => u.Id == id);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}

