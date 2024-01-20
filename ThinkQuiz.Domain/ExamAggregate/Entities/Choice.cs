namespace ThinkQuiz.Domain.ExamAggregate.Entities
{
    public class Choice
	{
        public Guid Id { get; private set; }

        public Guid QuestionId { get; private set; }

        public int Number { get; private set; }

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        private Choice(
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

        public static Choice Create(
            Guid quesiontId,
            int number,
            string title)
        {
            return new(
                Guid.NewGuid(),
                quesiontId,
                number,
                title);
        }

#pragma warning disable CS8618
        private Choice() { }
#pragma warning restore CS8618
    }
}

