namespace ThinkQuiz.Domain.TeacherAggregate
{
    public class Teacher
	{
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

		public string Position { get; private set; }

		public string SchoolInforamtion { get; private set; }

        public DateTime CreatedAt { get; private set; }

		public DateTime? UpdatedAt { get; private set; }

        private Teacher(
            Guid id,
            Guid userId,
            string position,
            string schoolInformation,
            DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Position = position;
            SchoolInforamtion = schoolInformation;
            CreatedAt = createdAt;
        }

        public static Teacher Create(
            Guid userId,
            string position,
            string schoolInformation
            )
        {
            return new(
                Guid.NewGuid(),
                userId,
                position,
                schoolInformation,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Teacher() { }
#pragma warning restore CS8618
    }
}

