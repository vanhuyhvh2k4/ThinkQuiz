using System;
using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects
{
    public class SubmittionAnswerId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private SubmittionAnswerId(Guid value)
        {
            Value = value;
        }

        public static SubmittionAnswerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static SubmittionAnswerId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

