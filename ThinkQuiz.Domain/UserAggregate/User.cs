﻿using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Domain.UserAggregate
{
    public class User : AggregateRoot<UserId, Guid>
    {
        public string FullName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool? Gender { get; private set; }

        public DateOnly? DateOfBirth { get; private set; }

        public string? Phone { get; private set; }

        public DateTime LastLogin { get; private set; }

        public StudentId StudentId { get; private set; }

        public TeacherId TeacherId { get; private set; }

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

