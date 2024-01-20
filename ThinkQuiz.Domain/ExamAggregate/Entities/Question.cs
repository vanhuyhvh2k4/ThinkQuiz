namespace ThinkQuiz.Domain.ExamAggregate.Entities
{
    public class Question
	{
        public Guid Id { get; private set; }

        public Guid ExamId { get; private set; }

        public int Number { get; private set; }

        public string Title { get; private set; }

        public double Point { get; private set; }

        public Guid CorrectAnswer { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        private Question(
            Guid id,
            Guid examId,
            int number,
            string title,
            double point)
        {
            Id = id;
            ExamId = examId;
            Number = number;
            Title = title;
            Point = point;
        }

        public static Question Create(
            Guid examId,
            int number,
            string title,
            double point)
        {
            return new(
                Guid.NewGuid(),
                examId,
                number,
                title,
                point);
        }

#pragma warning disable CS8618
        private Question() { }
#pragma warning restore CS8618
    }
}

