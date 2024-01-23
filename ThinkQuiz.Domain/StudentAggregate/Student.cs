using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate;
using ThinkQuiz.Domain.SubmittionExamAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Domain.StudentAggregate
{
    public class Student
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; } = null!;

        public ICollection<Class>? Classes { get; private set; }

        public ICollection<ClassStudent>? ClassStudents { get; private set; }

        public ICollection<SubmittionExam>? SubmittionExams { get; private set; }

        public ICollection<SubmittionAssignment>? SubmittionAssignments { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Student(
            Guid id,
            Guid userId,
            DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static Student Create(Guid userId)
        {
            return new(
                Guid.NewGuid(),
                userId,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Student() { }
#pragma warning restore CS8618
    }
}

