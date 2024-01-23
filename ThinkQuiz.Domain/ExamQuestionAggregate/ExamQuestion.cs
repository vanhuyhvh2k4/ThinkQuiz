using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.ExamChoiceAggregate;

namespace ThinkQuiz.Domain.ExamQuestionAggregate
{
    public class ExamQuestion
    {
        public Guid Id { get; private set; }

        public Exam Exam { get; private set; }

        public int Number { get; private set; }

        public string Title { get; private set; }

        public double Point { get; private set; }

        public Guid CorrectAnswer { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public List<ExamChoice> ExamChoices { get; private set; }

        private ExamQuestion(
            Guid id,
            Exam exam,
            int number,
            string title,
            double point,
            List<ExamChoice> examChoices)
        {
            Id = id;
            Exam = exam;
            Number = number;
            Title = title;
            Point = point;
            ExamChoices = examChoices;
        }

        public static ExamQuestion Create(
            Exam exam,
            int number,
            string title,
            double point,
            List<ExamChoice> examChoices)
        {
            return new(
                Guid.NewGuid(),
                exam,
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

