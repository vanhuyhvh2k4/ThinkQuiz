using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId, Guid>
	{
		public string FullName { get; private set; }

		public string Email { get; private set; }

		public string Password { get; private set; }

		public bool? Gender { get; private set; }

		public DateTime? DateOfBirth { get; private set; }

		public string? Phone { get; private set; }

		public DateTime LastLogin { get; private set; }

		public DateTime CreatedAt { get; private set; }

		public DateTime UpdatedAt { get; private set; }

        private User(
            UserId id,
            string fullName,
            string email,
            string password,
            DateTime lastLogin,
            DateTime createdAt,
            DateTime updatedAt) : base(id)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            LastLogin = lastLogin;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        // public methods
        public static User Create(
            string fullName,
            string email,
            string password
            )
        {
            return new(
                UserId.CreateUnique(),
                fullName,
                email,
                password,
                DateTime.UtcNow,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private User() { }
#pragma warning restore CS8618
    }
}

