using ThinkQuiz.Domain.ClassAggregate.ValueObjects;
using ThinkQuiz.Domain.Common.Models;
using ThinkQuiz.Domain.ExamAggregate.Entities;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;
using ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;

namespace ThinkQuiz.Domain.ExamAggregate
{
    public class Exam : AggregateRoot<ExamId, Guid>
	{
        private readonly List<Question> _questions = new();

        private readonly List<ClassId> _classIds = new();

        private readonly List<SubmittionExamId> _submittionExamIds = new();

        public TeacherId AuthorId { get; private set; }

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

        public IReadOnlyList<Question> Questions => _questions.AsReadOnly();

        public IReadOnlyList<ClassId> ClassIds => _classIds.AsReadOnly();

        public IReadOnlyList<SubmittionExamId> SubmittionExamIds => _submittionExamIds.AsReadOnly();

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Exam(
            ExamId id,
            TeacherId authorId,
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
            DateTime createdAt) : base(id)
        {
            AuthorId = authorId;
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
            TeacherId authorId,
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
                ExamId.CreateUnique(),
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

#pragma warning disable CS8618
        private Exam() { }
#pragma warning restore CS8618
    }
}

