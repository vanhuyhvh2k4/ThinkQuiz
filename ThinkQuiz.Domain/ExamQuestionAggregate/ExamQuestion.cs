using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.ExamChoiceAggregate;

namespace ThinkQuiz.Domain.ExamQuestionAggregate
{
    public class ExamQuestion
    {
        public Guid Id { get; private set; }

        public Guid ExamId { get; private set; }

        public Exam Exam { get; private set; } = null!;

        public int Number { get; private set; }

        public string Title { get; private set; }

        public double Point { get; private set; }

        public Guid CorrectAnswer { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public ICollection<ExamChoice> ExamChoices { get; private set; }

        private ExamQuestion(
            Guid id,
            Guid examId,
            int number,
            string title,
            double point,
            ICollection<ExamChoice> examChoices)
        {
            Id = id;
            ExamId = examId;
            Number = number;
            Title = title;
            Point = point;
            ExamChoices = examChoices;
        }

        public static ExamQuestion Create(
            Guid examId,
            int number,
            string title,
            double point,
            ICollection<ExamChoice> examChoices)
        {
            return new(
                Guid.NewGuid(),
                examId,
                number,
                title,
                point,
                examChoices);
        }

#pragma warning disable CS8618
        private ExamQuestion() { }
#pragma warning restore CS8618
    }
}

