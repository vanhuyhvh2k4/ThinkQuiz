using System;
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

        public List<Class> GetClassByTeacherId(Guid teacherId)
        {
            return _context.Classes.Where(c => c.TeacherId == teacherId).ToList();
        }
    }
}

