using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.SubmittionExamAnswerAggregate;

namespace ThinkQuiz.Domain.SubmittionExamAggregate
{
    public class SubmittionExam 
	{
        public Guid Id { get; private set; }

        public Student Student { get; private set; }

        public Exam Exam { get; private set; }

        public double? Point { get; private set; }

        public List<SubmittionExamAnswer> SubmittionExamAnswers { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionExam(
            Guid id,
            Student student,
            Exam exam,
            List<SubmittionExamAnswer> submittionExamAnswers,
            DateTime createdAt)
        {
            Id = id;
            Student = student;
            Exam = exam;
            SubmittionExamAnswers = submittionExamAnswers;
            CreatedAt = createdAt;
        }

        public static SubmittionExam Create(
            Student student,
            Exam exam,
            List<SubmittionExamAnswer> submittionExamAnswers)
        {
            return new(
                Guid.NewGuid(),
                student,
                exam,
                submittionExamAnswers,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionExam() { }
#pragma warning restore CS8618
    }
}

