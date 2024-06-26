﻿using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassAggregate;
using Microsoft.EntityFrameworkCore;

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

        public Class? GetClassById(Guid classId, bool status = false)
        {
            return _context.Classes.Where(c => c.Id == classId && c.IsDeleted == status)
                .Include(c => c.Teacher.User)
                .FirstOrDefault();
        }

        public List<Class> GetClassesByTeacherId(Guid teacherId, bool status = false)
        {
            return _context.Classes.Where(c => c.TeacherId == teacherId && c.IsDeleted == status)
                .Include(c => c.Teacher.User)
                .ToList();
        }

        public void Update(Class @class)
        {
            _context.Classes.Update(@class);
            _context.SaveChanges();
        }
    }
}

