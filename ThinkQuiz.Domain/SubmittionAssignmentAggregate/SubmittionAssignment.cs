using ThinkQuiz.Domain.AssignmentAggregate.ValueObjects;
using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate.ValueObjects;

namespace ThinkQuiz.Domain.SubmittionAssignmentAggregate
{
    public class SubmittionAssignment : AggregateRoot<SubmittionAssignmentId, Guid>
	{
        public StudentId StudentId { get; private set; }

        public AssignmentId AssignmentId { get; private set; }

        public string AnswerUrl { get; private set; }

        public double? Point { get; private set; }

        public string? Comment { get; private set; }

        public bool IsShowPoint { get; private set; }

        public bool IsSubmitAgain { get; private set; } = false;

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionAssignment(
            SubmittionAssignmentId id,
            StudentId studentId,
            AssignmentId assignmentId,
            string answerUrl,
            DateTime createdAt) : base(id)
        {
            StudentId = studentId;
            AssignmentId = assignmentId;
            AnswerUrl = answerUrl;
            CreatedAt = createdAt;
        }

        public static SubmittionAssignment Create(
            StudentId studentId,
            AssignmentId assignmentId,
            string answerUrl)
        {
            return new(
                SubmittionAssignmentId.CreateUnique(),
                studentId,
                assignmentId,
                answerUrl,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionAssignment() { }
#pragma warning restore CS8618
    }
}

