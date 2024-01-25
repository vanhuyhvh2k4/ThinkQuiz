using ThinkQuiz.Domain.ClassAssignmentAggregate;
using ThinkQuiz.Domain.ClassExamAggregate;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Domain.ClassAggregate
{
    public class Class
	{
        public Guid Id { get; private set; }

        public Guid TeacherId { get; private set; }

        public Teacher Teacher { get; private set; } = null!;

        public string Name { get; private set; }

        public string SchoolYear { get; private set; }

        public double StudentQuantity { get; private set; } = 0;

        public bool IsDeleted { get; private set; } = false;

        public ICollection<ClassStudent>? ClassStudents { get; private set; }

        public ICollection<ClassAssignment>? ClassAssignments { get; private set; }

        public ICollection<ClassExam>? ClassExams { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        private Class(
            Guid id,
            Guid teacherId,
            string name,
            string schoolYear,
            DateTime createdAt
            )
        {
            Id = id;
            TeacherId = teacherId;
            Name = name;
            SchoolYear = schoolYear;
            CreatedAt = createdAt;
        }

        public static Class Create(
            Guid teacherId,
            string name,
            string schoolYear)
        {
            return new(
                Guid.NewGuid(),
                teacherId,
                name,
                schoolYear,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Class() { }
#pragma warning restore CS8618
    }
}

