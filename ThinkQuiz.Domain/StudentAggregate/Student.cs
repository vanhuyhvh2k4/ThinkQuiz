namespace ThinkQuiz.Domain.StudentAggregate
{
    public class Student
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

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

