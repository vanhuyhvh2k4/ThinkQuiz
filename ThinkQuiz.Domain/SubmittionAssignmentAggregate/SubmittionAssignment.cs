using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Domain.SubmittionAssignmentAggregate
{
    public class SubmittionAssignment
	{
        public Guid Id { get; private set; }

        public Student Student { get; private set; }

        public Assignment Assignment { get; private set; }

        public string AnswerUrl { get; private set; }

        public double? Point { get; private set; }

        public string? Comment { get; private set; }

        public bool IsShowPoint { get; private set; }

        public bool IsSubmitAgain { get; private set; } = false;

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionAssignment(
            Guid id,
            Student student,
            Assignment assignment,
            string answerUrl,
            DateTime createdAt)
        {
            Id = id;
            Student = student;
            Assignment = assignment;
            AnswerUrl = answerUrl;
            CreatedAt = createdAt;
        }

        public static SubmittionAssignment Create(
            Student student,
            Assignment assignment,
            string answerUrl)
        {
            return new(
                Guid.NewGuid(),
                student,
                assignment,
                answerUrl,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionAssignment() { }
#pragma warning restore CS8618
    }
}

