using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Repositories
{
    public class ClassStudentRepository : IClassStudentRepository
	{
        private readonly ThinkQuizDbContext _context;

        public ClassStudentRepository(ThinkQuizDbContext context)
        {
            _context = context;
        }

        public void Add(ClassStudent classStudent)
        {
            _context.ClassStudents.Add(classStudent);
            _context.SaveChanges();
        }

        public ClassStudent? Get(Guid studentId, Guid classId)
        {
            return _context.ClassStudents.SingleOrDefault(cs => cs.StudentId == studentId && cs.ClassId == classId);
        }
    }
}

