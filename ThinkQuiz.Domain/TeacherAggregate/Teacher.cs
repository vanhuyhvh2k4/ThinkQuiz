using ThinkQuiz.Domain.AssignmentAggregate.ValueObjects;
using ThinkQuiz.Domain.ClassAggregate.ValueObjects;
using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Domain.TeacherAggregate
{
    public class Teacher : AggregateRoot<TeacherId, Guid>
	{
        private readonly List<ClassId> _classIds = new();

        private readonly List<AssignmentId> _assignmentIds = new();

        private readonly List<ExamId> _examIds = new();

		public UserId UserId { get; private set; }

		public string Position { get; private set; }

		public string SchoolInforamtion { get; private set; }

        public IReadOnlyList<ClassId> ClassIds => _classIds.AsReadOnly();

        public IReadOnlyList<AssignmentId> AssignmentIds => _assignmentIds.AsReadOnly();

        public IReadOnlyList<ExamId> ExamIds => _examIds.AsReadOnly();

        public DateTime CreatedAt { get; private set; }

		public DateTime? UpdatedAt { get; private set; }

        private Teacher(
            TeacherId id,
            UserId userId,
            string position,
            string schoolInformation,
            DateTime createdAt) : base(id)
        {
            UserId = userId;
            Position = position;
            SchoolInforamtion = schoolInformation;
            CreatedAt = createdAt;
        }

        public static Teacher Create(
            UserId userId,
            string position,
            string schoolInformation
            )
        {
            return new(
                TeacherId.CreateUnique(),
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

