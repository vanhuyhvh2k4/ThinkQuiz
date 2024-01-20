using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;
using ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects;

namespace ThinkQuiz.Domain.SubmittionExamAggregate.Entities
{
    public class SubmittionAnswer : Entity<SubmittionAnswerId>
	{
        public QuestionId QuestionId { get; private set; }

        public ChoiceId ChoiceId { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private SubmittionAnswer(
            SubmittionAnswerId id,
            QuestionId questionId,
            ChoiceId choiceId,
            DateTime createdAt) : base(id)
        {
            QuestionId = questionId;
            ChoiceId = choiceId;
            CreatedAt = createdAt;
        }

        public static SubmittionAnswer Create(
            QuestionId questionId,
            ChoiceId choiceId)
        {
            return new(
                SubmittionAnswerId.CreateUnique(),
                questionId,
                choiceId,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private SubmittionAnswer() { }
#pragma warning restore CS8618
    }
}

