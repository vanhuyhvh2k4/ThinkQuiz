using System;
using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.ExamAggregate.ValueObjects
{
    public class ChoiceId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private ChoiceId(Guid value)
        {
            Value = value;
        }

        public static ChoiceId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ChoiceId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

