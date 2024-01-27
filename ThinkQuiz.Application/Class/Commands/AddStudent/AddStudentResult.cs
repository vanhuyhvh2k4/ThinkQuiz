namespace ThinkQuiz.Application.Class.Commands.AddStudent
{
    public record AddStudentResult(
        string StudentId,
        string ClassId,
        bool Status,
        string CreatedAt,
        string UpdatedAt);
}

