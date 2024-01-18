using System;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Repositories
{
	public class UserRepository : IUserRepository
	{
        private static readonly List<User> _users = new();

        private readonly ThinkQuizDbContext _context;

        public UserRepository(ThinkQuizDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);

            _context.SaveChangesAsync();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

            _context.SaveChangesAsync();
        }
    }
}

