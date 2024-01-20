using System;
using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.SubmittionAssignmentAggregate.ValueObjects
{
    public class SubmittionAssignmentId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private SubmittionAssignmentId(Guid value)
        {
            Value = value;
        }

        public static SubmittionAssignmentId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static SubmittionAssignmentId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

