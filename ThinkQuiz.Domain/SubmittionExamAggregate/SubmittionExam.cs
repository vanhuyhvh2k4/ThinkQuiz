namespace ThinkQuiz.Domain.SubmittionExamAggregate
{
    public class SubmittionExam
	{
        public Guid Id { get; private set; }

        public Guid StudentId { get; private set; }

        public Guid ExamId { get; private set; }

        public double? Point { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionExam(
            Guid id,
            Guid studentId,
            Guid examId,
            DateTime createdAt)
        {
            Id = id;
            StudentId = studentId;
            ExamId = examId;
            CreatedAt = createdAt;
        }

        public static SubmittionExam Create(
            Guid studentId,
            Guid examId)
        {
            return new(
                Guid.NewGuid(),
                studentId,
                examId,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionExam() { }
#pragma warning restore CS8618
    }
}

