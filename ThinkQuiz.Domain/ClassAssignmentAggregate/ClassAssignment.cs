using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Domain.ClassAssignmentAggregate
{
    public class ClassAssignment
	{
		public Guid ClassId { get; private set; }

		public Guid AssignmentId { get; private set; }

		public Class Class { get; private set; } = null!;

		public Assignment Assignment { get; private set; } = null!;

		private ClassAssignment(Guid classId, Guid assignmentId)
		{
			ClassId = classId;
			AssignmentId = assignmentId;
		}

		public static ClassAssignment Create(Guid classId, Guid assignmentId)
		{
			return new(classId, assignmentId);
		}

#pragma warning disable CS8618
        private ClassAssignment() { }
#pragma warning restore CS8618
    }
}

