using ThinkQuiz.Domain.ExamQuestionAggregate;

namespace ThinkQuiz.Domain.ExamChoiceAggregate
{
    public class ExamChoice 
    {
        public Guid Id { get; private set; }

        public ExamQuestion ExamQuestion { get; private set; }

        public int Number { get; private set; }

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        private ExamChoice(
            Guid id,
            ExamQuestion examQuestion,
            int number,
            string title)
        {
            Id = id;
            ExamQuestion = examQuestion;
            Number = number;
            Title = title;
        }

        public static ExamChoice Create(
            ExamQuestion examQuestion,
            int number,
            string title)
        {
            return new(
                Guid.NewGuid(),
                examQuestion,
                number,
                title);
        }

#pragma warning disable CS8618
        private ExamChoice() { }
#pragma warning restore CS8618
    }
}

