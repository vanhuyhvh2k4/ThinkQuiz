using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.StudeæntAggregate;

namespace ThinkQuiz.Domain.ClassStudentAggregate
{
    public class ClassStudent
	{
		public Guid StudentId { get; private set; }

		public Guid ClassId { get; private set; }

		public Student Student { get; private set; } = null!;

		public Class Class { get; private set; } = null!;

		public DateTime CreatedAt { get; private set; }

		public DateTime? UpdatedAt { get; private set; }

		private ClassStudent(Guid studentId, Guid classId, DateTime createdAt)
		{
			StudentId = studentId;
			ClassId = classId;
			CreatedAt = createdAt;
		}

		public static ClassStudent Create(Guid studentId, Guid classId)
		{
			return new(studentId, classId, DateTime.Now);
		}

#pragma warning disable CS8618
        private ClassStudent() { }
#pragma warning restore CS8618
    }
}

