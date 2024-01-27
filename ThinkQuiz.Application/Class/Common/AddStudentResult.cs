namespace ThinkQuiz.Application.Class.Common
{
    public record AddStudentResult(
        string StudentId,
        string ClassId,
        bool Status,
        string CreatedAt,
        string UpdatedAt);
}

