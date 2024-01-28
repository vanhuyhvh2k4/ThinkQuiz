using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Repositories
{
    public class ClassRepository : IClassRepository
	{
        private readonly ThinkQuizDbContext _context;

        public ClassRepository(ThinkQuizDbContext context)
        {
            _context = context;
        }

        public void Create(Class newClass)
        {
            _context.Classes.Add(newClass);

            _context.SaveChanges();
        }

        public Class? GetClassById(Guid classId)
        {
            return _context.Classes.SingleOrDefault(c => c.Id == classId);
        }

        public List<Class> GetClassByTeacherId(Guid teacherId)
        {
            return _context.Classes.Where(c => c.TeacherId == teacherId)
                .ToList();
        }
    }
}

