using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Domain.ClassStudentAggregate
{
    public class ClassStudent
	{
		public Student Student { get; private set; }

		public Class Class { get; private set; }

		public DateTime CreatedAt { get; private set; }

		public DateTime? UpdatedAt { get; private set; }

		private ClassStudent(Student student, Class @class, DateTime createdAt)
		{
			Student = student;
			Class = @class;
			CreatedAt = createdAt;
		}

		public static ClassStudent Create(Student student, Class @class)
		{
			return new(student, @class, DateTime.Now);
		}

#pragma warning disable CS8618
        private ClassStudent() { }
#pragma warning restore CS8618
    }
}

