using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ExamAggregate;

namespace ThinkQuiz.Domain.ClassExamAggregate
{
    public class ClassExam
	{
		public Class Class { get; private set; }

		public Exam Exam { get; private set; }

		private ClassExam(Class @class, Exam exam)
		{
			Class = @class;
			Exam = exam;
		}

		public static ClassExam Create(Class @class, Exam exam)
		{
			return new(@class, exam);
		}

#pragma warning disable CS8618
        private ClassExam() { }
#pragma warning restore CS8618
    }
}

