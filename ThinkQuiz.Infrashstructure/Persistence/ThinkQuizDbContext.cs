using Microsoft.EntityFrameworkCore;
using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence
{
    public class ThinkQuizDbContext : DbContext
    {
        public ThinkQuizDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<SubmittionAssignment> SubmittionAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThinkQuizDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

