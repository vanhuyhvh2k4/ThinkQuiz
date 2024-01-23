using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Domain.TeacherAggregate
{
    public class Teacher
	{
        public Guid Id { get; private set; }

        public User User { get; private set; }

		public string Position { get; private set; }

		public string SchoolInforamtion { get; private set; }

        public List<Class>? Classes { get; private set; }

        public List<Assignment>? Assignments { get; private set; }

        public List<Exam>? Exams { get; private set; }

        public DateTime CreatedAt { get; private set; }

		public DateTime? UpdatedAt { get; private set; }

        private Teacher(
            Guid id,
            User user,
            string position,
            string schoolInformation,
            DateTime createdAt)
        {
            Id = id;
            User = user;
            Position = position;
            SchoolInforamtion = schoolInformation;
            CreatedAt = createdAt;
        }

        public static Teacher Create(
            User user,
            string position,
            string schoolInformation
            )
        {
            return new(
                Guid.NewGuid(),
                user,
                position,
                schoolInformation,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Teacher() { }
#pragma warning restore CS8618
    }
}

