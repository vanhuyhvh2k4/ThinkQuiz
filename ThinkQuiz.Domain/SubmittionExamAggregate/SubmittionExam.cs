using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.StudeæntAggregate;
using ThinkQuiz.Domain.SubmittionExamAnswerAggregate;

namespace ThinkQuiz.Domain.SubmittionExamAggregate
{
    public class SubmittionExam 
	{
        public Guid Id { get; private set; }

        public Guid StudentId { get; private set; }

        public Student Student { get; private set; } = null!;

        public Guid ExamId { get; private set; }

        public Exam Exam { get; private set; } = null!;

        public double? Point { get; private set; }

        public ICollection<SubmittionExamAnswer> SubmittionExamAnswers { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionExam(
            Guid id,
            Guid studentId,
            Guid examId,
            ICollection<SubmittionExamAnswer> submittionExamAnswers,
            DateTime createdAt)
        {
            Id = id;
            StudentId = studentId;
            ExamId = examId;
            SubmittionExamAnswers = submittionExamAnswers;
            CreatedAt = createdAt;
        }

        public static SubmittionExam Create(
            Guid studentId,
            Guid examId,
            ICollection<SubmittionExamAnswer> submittionExamAnswers)
        {
            return new(
                Guid.NewGuid(),
                studentId,
                examId,
                submittionExamAnswers,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionExam() { }
#pragma warning restore CS8618
    }
}

