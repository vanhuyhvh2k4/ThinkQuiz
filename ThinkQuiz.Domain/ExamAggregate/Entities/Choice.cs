using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;

namespace ThinkQuiz.Domain.ExamAggregate.Entities
{
    public class Choice : Entity<ChoiceId>
	{
        public int Number { get; private set; }

        public string Title { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        private Choice(
            ChoiceId id,
            int number,
            string title) : base(id)
        {
            Number = number;
            Title = title;
        }

        public static Choice Create(
            int number,
            string title)
        {
            return new(
                ChoiceId.CreateUnique(),
                number,
                title);
        }

#pragma warning disable CS8618
        private Choice() { }
#pragma warning restore CS8618
    }
}

