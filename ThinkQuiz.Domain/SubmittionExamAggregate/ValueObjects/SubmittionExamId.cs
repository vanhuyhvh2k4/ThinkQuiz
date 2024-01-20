using System;
using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects
{
    public class SubmittionExamId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private SubmittionExamId(Guid value)
        {
            Value = value;
        }

        public static SubmittionExamId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static SubmittionExamId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

