using ThinkQuiz.Domain.ClassExamAggregate;
using ThinkQuiz.Domain.ExamQuestionAggregate;
using ThinkQuiz.Domain.SubmittionExamAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Domain.ExamAggregate
{
    public class Exam
	{
        public Guid Id { get; private set; }

        public Teacher Teacher { get; private set; }

        public string Name { get; private set; }

        public string? Password{ get; private set; }

        public bool IsPublish { get; private set; } = false;

        public bool IsWrap { get; private set; } = false;

        public bool IsShowResult { get; private set; } = false;

        public bool IsShowPoint { get; private set; } = false;

        public bool IsDeleted { get; private set; } = false;

        public int LimitAttemptNumber { get; private set; } = 1;

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public int Duration { get; private set; }

        public List<ClassExam>? ClassExams { get; private set; }

        public List<SubmittionExam>? SubmittionExams { get; private set; }

        public List<ExamQuestion> ExamQuestions { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Exam(
            Guid id,
            Teacher teacher,
            string name,
            string password,
            bool isPublish,
            bool isWrap,
            bool isShowResult,
            bool isShowPoint,
            int limitAttemptNumber,
            List<ExamQuestion> examQuestions,
            DateTime startTime,
            DateTime endTime,
            int duration,
            DateTime createdAt)
        {
            Id = id;
            Teacher = teacher;
            Name = name;
            Password = password;
            IsPublish = isPublish;
            IsWrap = isWrap;
            IsShowPoint = isShowPoint;
            IsShowResult = isShowResult;
            LimitAttemptNumber = limitAttemptNumber;
            ExamQuestions = examQuestions;
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
            CreatedAt = createdAt;
        }

        public static Exam Create(
            Teacher teacher,
            string name,
            string password,
            bool isPublish,
            bool isWrap,
            bool isShowResult,
            bool isShowPoint,
            int limitAttemptNumber,
            List<ExamQuestion> examQuestions,
            DateTime startTime,
            DateTime endTime,
            int duration)
        {
            return new(
                Guid.NewGuid(),
                teacher,
                name,
                password,
                isPublish,
                isWrap,
                isShowResult,
                isShowPoint,
                limitAttemptNumber,
                examQuestions,
                startTime,
                endTime,
                duration,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Exam() { }
#pragma warning restore CS8618
    }
}

