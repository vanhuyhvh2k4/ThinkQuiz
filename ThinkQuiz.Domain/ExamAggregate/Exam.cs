namespace ThinkQuiz.Domain.ExamAggregate
{
    public class Exam
	{
        public Guid Id { get; private set; }

        public Guid TeacherId { get; private set; }

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
            StartTime = startTime;
            EndTime = endTime;
            Duration = duration;
            CreatedAt = createdAt;
        }

        public static Exam Create(
            Guid authorId,
            string name,
            string password,
            bool isPublish,
            bool isWrap,
            bool isShowResult,
            bool isShowPoint,
            int limitAttemptNumber,
            DateTime startTime,
            DateTime endTime,
            int duration)
        {
            return new(
                Guid.NewGuid(),
                authorId,
                name,
                password,
                isPublish,
                isWrap,
                isShowResult,
                isShowPoint,
                limitAttemptNumber,
                startTime,
                endTime,
                duration,
                DateTime.Now);
        }
    }
}

