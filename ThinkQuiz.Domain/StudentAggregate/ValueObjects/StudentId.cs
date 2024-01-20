using System;
using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.StudentAggregate.ValueObjects
{
    public class StudentId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private StudentId(Guid value)
        {
            Value = value;
        }

        public static StudentId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static StudentId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

