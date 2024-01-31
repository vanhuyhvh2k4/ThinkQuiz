using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Domain.UserAggregate
{
    public class User
    {
        public Guid Id { get; private set; }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool CurrentRole { get; private set; }

        public bool Gender { get; private set; } = true;

        public DateOnly? DateOfBirth { get; private set; }

        public string? Phone { get; private set; }

        public DateTime LastLogin { get; private set; }

        public DateTime CreatedAt { get; private set; } 

        public DateTime UpdatedAt { get; private set; }

        // Reference navigation to dependent

        public Teacher? Teacher { get; private set; }

        public Student? Student { get; private set; }

        private User(
            Guid id,
            string fullName,
            string email,
            string password,
            bool currentRole,
            DateTime lastLogin,
            DateTime createdAt,
            DateTime updatedAt) 
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            CurrentRole = currentRole;
            LastLogin = lastLogin;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        // public methods
        public static User Create(
            string fullName,
            string email,
            string password,
            bool currentRole
            )
        {
            return new(
                Guid.NewGuid(),
                fullName,
                email,
                password,
                currentRole,
                DateTime.Now,
                DateTime.Now,
                DateTime.Now);
        }

        public void UpdateLastLogin()
        {
            LastLogin = DateTime.Now;
        }

        public void Update(
            string? fullName = null,
            string? email = null,
            string? password = null,
            bool? gender = null,
            DateOnly? dateOfBirth = null,
            string? phone = null)
        {
            FullName = fullName ?? FullName;
            Email = email ?? Email;
            Password = password ?? Password;
            Gender = gender ?? Gender;
            DateOfBirth = dateOfBirth;
            Phone = phone ?? Phone;
            UpdatedAt = DateTime.Now;
        }
#pragma warning disable CS8618
        private User() { }
#pragma warning restore CS8618
    }
}

