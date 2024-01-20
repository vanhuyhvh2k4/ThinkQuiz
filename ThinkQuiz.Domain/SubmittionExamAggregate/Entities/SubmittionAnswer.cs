namespace ThinkQuiz.Domain.SubmittionExamAggregate.Entities
{
    public class SubmittionAnswer
	{
        public Guid Id { get; private set; }

        public Guid QuestionId { get; private set; }

        public Guid ChoiceId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionAnswer(
            Guid id,
            Guid questionId,
            Guid choiceId,
            DateTime createdAt)
        {
            Id = id;
            QuestionId = questionId;
            ChoiceId = choiceId;
            CreatedAt = createdAt;
        }

        public static SubmittionAnswer Create(
            Guid questionId,
            Guid choiceId)
        {
            return new(
                Guid.NewGuid(),
                questionId,
                choiceId,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionAnswer() { }
#pragma warning restore CS8618
    }
}

