using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Domain.StudentAggregate
{
    public class Student : AggregateRoot<StudentId, Guid>
    {
        public UserId UserId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Student(
            StudentId id,
            UserId userId,
            DateTime createdAt) : base(id)
        {
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static Student Create(UserId userId)
        {
            return new(
                StudentId.CreateUnique(),
                userId,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Student() { }
#pragma warning restore CS8618
    }
}

