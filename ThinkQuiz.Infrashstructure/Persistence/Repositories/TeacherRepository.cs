using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Repositories
{
    public class TeacherRepository : ITeacherRepository
	{
        private readonly ThinkQuizDbContext _context;

        public TeacherRepository(ThinkQuizDbContext context)
        {
            _context = context;
        }

        public void Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);

            _context.SaveChanges();
        }

        public Teacher? GetTeacherByUserId(Guid userId)
        {
            return _context.Teachers.SingleOrDefault(t => t.UserId == userId);
        }
    }
}

