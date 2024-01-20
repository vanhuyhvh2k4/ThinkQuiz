using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Domain.TeacherAggregate
{
    public class Teacher : AggregateRoot<TeacherId, Guid>
	{
		public UserId UserId { get; private set; }

		public string? Position { get; private set; }

		public string? SchoolInforamtion { get; private set; }

		public DateTime CreatedAt { get; private set; }

		public DateTime UpdatedAt { get; private set; }

        private Teacher(
            TeacherId id,
            UserId userId,
            string? position,
            string? schoolInformation,
            DateTime createdAt,
            DateTime updatedAt) : base(id)
        {
            UserId = userId;
            Position = position;
            SchoolInforamtion = schoolInformation;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Teacher Create(
            UserId userId,
            string? position,
            string? schoolInformation
            )
        {
            return new(
                TeacherId.CreateUnique(),
                userId,
                position,
                schoolInformation,
                DateTime.Now,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Teacher() { }
#pragma warning restore CS8618
    }
}

