using ThinkQuiz.Domain.ClassStudentAggregate;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate;
using ThinkQuiz.Domain.SubmittionExamAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Domain.StudentAggregate
{
    public class Student
    {
        public Guid Id { get; private set; }

        public User User { get; private set; }

        public List<ClassStudent>? ClassStudents { get; private set; }

        public List<SubmittionExam>? SubmittionExams { get; private set; }

        public List<SubmittionAssignment>? SubmittionAssignments { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Student(
            Guid id,
            User user,
            DateTime createdAt)
        {
            Id = id;
            User = user;
            CreatedAt = createdAt;
        }

        public static Student Create(User user)
        {
            return new(
                Guid.NewGuid(),
                user,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Student() { }
#pragma warning restore CS8618
    }
}

