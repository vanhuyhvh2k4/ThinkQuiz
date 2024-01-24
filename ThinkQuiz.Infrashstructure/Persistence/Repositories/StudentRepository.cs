using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
	{
        private readonly ThinkQuizDbContext _context;

        public StudentRepository(ThinkQuizDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}

