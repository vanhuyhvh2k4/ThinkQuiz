using ThinkQuiz.Domain.Common.Models;

namespace ThinkQuiz.Domain.TeacherAggregate.ValueObjects
{
    public class TeacherId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private TeacherId(Guid value)
        {
            Value = value;
        }

        public static TeacherId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static TeacherId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

