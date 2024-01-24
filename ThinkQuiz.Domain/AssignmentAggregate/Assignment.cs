using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassAssignmentAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Domain.AssignmentAggregate
{
    public class Assignment
	{
        public Guid Id { get; private set; }

        public Guid TeacherId { get; private set; }

        public Teacher Teacher { get; private set; } = null!;

        public string Name { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public string? Content { get; private set; }

        public string FileUrl { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public ICollection<Class>? Classes { get; private set; }

        public ICollection<ClassAssignment>? ClassAssignments { get; private set; }

        public ICollection<Student>? Students { get; private set; }

        public ICollection<SubmittionAssignment>? SubmittionAssignments { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        private Assignment(
            Guid id,
            Guid teacherId,
            string name,
            DateTime startTime,
            DateTime endTime,
            string? content,
            string fileUrl,
            DateTime createdAt)
        {
            Id = id;
            TeacherId = teacherId;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Content = content;
            FileUrl = fileUrl;
            CreatedAt = createdAt;
        }

        public static Assignment Create(
            Guid teacherId,
            string name,
            DateTime startTime,
            DateTime endTime,
            string? content,
            string fileUrl)
        {
            return new(
                Guid.NewGuid(),
                teacherId,
                name,
                startTime,
                endTime,
                content,
                fileUrl,
                DateTime.Now);
        }

#pragma warning disable CS8618
        private Assignment() { }
#pragma warning restore CS8618
    }
}

