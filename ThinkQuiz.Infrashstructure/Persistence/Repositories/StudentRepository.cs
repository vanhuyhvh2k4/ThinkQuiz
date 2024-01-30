using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using Microsoft.EntityFrameworkCore;

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

        public Student? GetStudentById(Guid studentId)
        {
            return _context.Students.SingleOrDefault(s => s.Id == studentId);
        }

        public Student? GetStudentByUserId(Guid userId)
        {
            return _context.Students.SingleOrDefault(student => student.UserId == userId);
        }

        public List<Student> GetStudentsByClassId(Guid classId, bool status = true)
        {
            return _context.ClassStudents.Where(cs => cs.ClassId == classId && cs.Status == status)
                .Include(cs => cs.Student.User)
                .Select(cs => cs.Student)
                .ToList();
        }
    }
}

