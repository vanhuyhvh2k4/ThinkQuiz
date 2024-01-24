using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassExamAggregate;
using ThinkQuiz.Domain.ExamQuestionAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.SubmittionExamAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Domain.ExamAggregate
{
    public class Exam
	{
        public Guid Id { get; private set; }

        public Guid TeacherId { get; private set; }

        public Teacher Teacher { get; private set; } = null!;

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

        public ICollection<ClassExam>? ClassExams { get; private set; }

        public ICollection<SubmittionExam>? SubmittionExams { get; private set; }

        public ICollection<ExamQuestion> ExamQuestions { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Exam(
            Guid id,
            Guid teacherId,
            string name,
            string password,
            bool isPublish,
            bool isWrap,
            bool isShowResult,
            bool isShowPoint,
            int limitAttemptNumber,
            ICollection<ExamQuestion> examQuestions,
            DateTime startTime,
            DateTime endTime,
            int duration,
            DateTime createdAt)
        {
            Id = id;
            TeacherId = teacherId;
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
            Guid teacherId,
            string name,
            string password,
            bool isPublish,
            bool isWrap,
            bool isShowResult,
            bool isShowPoint,
            int limitAttemptNumber,
            ICollection<ExamQuestion> examQuestions,
            DateTime startTime,
            DateTime endTime,
            int duration)
        {
            return new(
                Guid.NewGuid(),
                teacherId,
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

