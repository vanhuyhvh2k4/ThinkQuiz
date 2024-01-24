using ThinkQuiz.Domain.ExamQuestionAggregate;

namespace ThinkQuiz.Domain.ExamChoiceAggregate
{
    public class ExamChoice 
    {
        public Guid Id { get; private set; }

        public Guid QuestionId { get; private set; }

        public ExamQuestion ExamQuestion { get; private set; } = null!;

        public int Number { get; private set; }

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        private ExamChoice(
            Guid id,
            Guid questionId,
            int number,
            string title)
        {
            Id = id;
            QuestionId = questionId;
            Number = number;
            Title = title;
        }

        public static ExamChoice Create(
            Guid questionId,
            int number,
            string title)
        {
            return new(
                Guid.NewGuid(),
                questionId,
                number,
                title);
        }

#pragma warning disable CS8618
        private ExamChoice() { }
#pragma warning restore CS8618
    }
}

