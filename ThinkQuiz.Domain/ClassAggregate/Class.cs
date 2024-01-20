using ThinkQuiz.Domain.ClassAggregate.ValueObjects;
using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;

namespace ThinkQuiz.Domain.ClassAggregate
{
    public class Class : AggregateRoot<ClassId, Guid>
	{
        public TeacherId TeacherId { get; private set; }

        public string Name { get; private set; }

        public string SchoolYear { get; private set; }

        public double StudentQuantity { get; private set; } = 0;

        public bool IsDeleted { get; private set; } = false;

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Class(
            ClassId id,
            TeacherId teacherId,
            string name,
            string schoolYear,
            DateTime createdAt
            ) : base(id)
        {
            TeacherId = teacherId;
            Name = name;
            SchoolYear = schoolYear;
            CreatedAt = createdAt;
        }

        public static Class Create(
            TeacherId teacherId,
            string name,
            string schoolYear)
        {
            return new(
                ClassId.CreateUnique(),
                teacherId,
                name,
                schoolYear,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Class() { }
#pragma warning restore CS8618
    }
}

