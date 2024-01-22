using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.SubmittionExamAggregate.Entities;
using ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects;

namespace ThinkQuiz.Domain.SubmittionExamAggregate
{
    public class SubmittionExam : AggregateRoot<SubmittionExamId, Guid>
	{
        private readonly List<SubmittionAnswer> _submittionAnswers = new();

        public StudentId StudentId { get; private set; }

        public ExamId ExamId { get; private set; }

        public double? Point { get; private set; }

        public IReadOnlyList<SubmittionAnswer> SubmittionAnswers => _submittionAnswers.AsReadOnly();

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionExam(
            SubmittionExamId id,
            StudentId studentId,
            ExamId examId,
            DateTime createdAt) : base(id)
        {
            StudentId = studentId;
            ExamId = examId;
            CreatedAt = createdAt;
        }

        public static SubmittionExam Create(
            SubmittionExamId id,
            StudentId studentId,
            ExamId examId,
            DateTime createdAt)
        {
            return new(
                SubmittionExamId.CreateUnique(),
                studentId,
                examId,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionExam() { }
#pragma warning restore CS8618
    }
}

