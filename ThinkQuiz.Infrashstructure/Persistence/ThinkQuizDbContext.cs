using Microsoft.EntityFrameworkCore;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.StudentAggregate;
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

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassStudent> ClassStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThinkQuizDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

