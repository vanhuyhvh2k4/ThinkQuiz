using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ExamAggregate;

namespace ThinkQuiz.Domain.ClassExamAggregate
{
    public class ClassExam
	{
		public Guid ClassId { get; private set; }

		public Guid ExamId { get; private set; }

		public Class Class { get; private set; } = null!;

		public Exam Exam { get; private set; } = null!;

		private ClassExam(Guid classId, Guid examId)
		{
			ClassId = classId;
			ExamId = examId;
		}

		public static ClassExam Create(Guid classId, Guid examId)
		{
			return new(classId, examId);
		}

#pragma warning disable CS8618
        private ClassExam() { }
#pragma warning restore CS8618
    }
}

