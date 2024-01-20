using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.ClassAggregate.ValueObjects
{
    public class ClassId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private ClassId(Guid value)
        {
            Value = value;
        }

        public static ClassId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ClassId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

