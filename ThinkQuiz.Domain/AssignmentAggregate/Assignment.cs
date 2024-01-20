using ThinkQuiz.Domain.AssignmentAggregate.ValueObjects;
using ThinkQuiz.Domain.ClassAggregate.ValueObjects;
using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;

namespace ThinkQuiz.Domain.AssignmentAggregate
{
    public class Assignment : AggregateRoot<AssignmentId, Guid>
	{
        private readonly List<ClassId> _classIds = new();

        private readonly List<SubmittionAssignmentId> _submittionAssignmentIds = new();

        public TeacherId AuthorId { get; private set; }

        public string Name { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public string? Content { get; private set; }

        public string FileUrl { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public IReadOnlyList<ClassId> ClassIds => _classIds.AsReadOnly();

        public IReadOnlyList<SubmittionAssignmentId> SubmittionAssignmentIds => _submittionAssignmentIds.AsReadOnly();

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Assignment(
            AssignmentId id,
            TeacherId authorId,
            string name,
            DateTime startTime,
            DateTime endTime,
            string? content,
            string fileUrl,
            DateTime createdAt) : base(id)
        {
            AuthorId = authorId;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Content = content;
            FileUrl = fileUrl;
            CreatedAt = createdAt;
        }

        public static Assignment Create(
            TeacherId authorId,
            string name,
            DateTime startTime,
            DateTime endTime,
            string? content,
            string fileUrl)
        {
            return new(
                AssignmentId.CreateUnique(),
                authorId,
                name,
                startTime,
                endTime,
                content,
                fileUrl,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Assignment() { }
#pragma warning restore CS8618
    }
}

