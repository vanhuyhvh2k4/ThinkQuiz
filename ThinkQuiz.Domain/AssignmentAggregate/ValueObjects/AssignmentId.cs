using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.AssignmentAggregate.ValueObjects
{
    public class AssignmentId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private AssignmentId(Guid value)
        {
            Value = value;
        }

        public static AssignmentId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static AssignmentId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

