using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.ExamAggregate.ValueObjects
{
    public class ExamId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private ExamId(Guid value)
        {
            Value = value;
        }

        public static ExamId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ExamId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

