using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.ClassAggregate;

namespace ThinkQuiz.Domain.ClassAssignmentAggregate
{
    public class ClassAssignment
	{
		public Class Class { get; private set; }

		public Assignment Assignment { get; private set; }

		private ClassAssignment(Class @class, Assignment assignment)
		{
			Class = @class;
			Assignment = assignment;
		}

		public static ClassAssignment Create(Class @class, Assignment assignment)
		{
			return new(@class, assignment);
		}

#pragma warning disable CS8618
        private ClassAssignment() { }
#pragma warning restore CS8618
    }
}

