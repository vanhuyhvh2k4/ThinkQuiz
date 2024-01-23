using ThinkQuiz.Domain.ClassAssignmentAggregate;
using ThinkQuiz.Domain.ClassExamAggregate;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Domain.ClassAggregate
{
    public class Class
	{
        public Guid Id { get; private set; }

        public Teacher Teacher { get; private set; }

        public string Name { get; private set; }

        public string SchoolYear { get; private set; }

        public double StudentQuantity { get; private set; } = 0;

        public bool IsDeleted { get; private set; } = false;

        public List<ClassStudent>? ClassStudents { get; private set; }

        public List<ClassAssignment>? ClassAssignments { get; private set; }

        public List<ClassExam>? ClassExams { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Class(
            Guid id,
            Teacher teacher,
            string name,
            string schoolYear,
            DateTime createdAt
            )
        {
            Id = id;
            Teacher = teacher;
            Name = name;
            SchoolYear = schoolYear;
            CreatedAt = createdAt;
        }

        public static Class Create(
            Teacher teacher,
            string name,
            string schoolYear)
        {
            return new(
                Guid.NewGuid(),
                teacher,
                name,
                schoolYear,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Class() { }
#pragma warning restore CS8618
    }
}

