using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.StudeæntAggregate;

namespace ThinkQuiz.Domain.SubmittionAssignmentAggregate
{
    public class SubmittionAssignment
	{
        public Guid Id { get; private set; }

        public Guid StudentId { get; private set; }

        public Student Student { get; private set; } = null!;

        public Guid AssignmentId { get; private set; }

        public Assignment Assignment { get; private set; } = null!;

        public string AnswerUrl { get; private set; }

        public double? Point { get; private set; }

        public string? Comment { get; private set; }

        public bool IsShowPoint { get; private set; }

        public bool IsSubmitAgain { get; private set; } = false;

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionAssignment(
            Guid id,
            Guid studentId,
            Guid assignmentId,
            string answerUrl,
            DateTime createdAt)
        {
            Id = id;
            StudentId = studentId;
            AssignmentId = assignmentId;
            AnswerUrl = answerUrl;
            CreatedAt = createdAt;
        }

        public static SubmittionAssignment Create(
            Guid studentId,
            Guid assignmentId,
            string answerUrl)
        {
            return new(
                Guid.NewGuid(),
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

