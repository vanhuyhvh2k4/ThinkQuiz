namespace ThinkQuiz.Application.Class.Common
{
    public record ClassResult(
        string Id,
        TeacherData Teacher,
        string Name,
        string SchoolYear,
        double StudentQuantity,
        string CreatedAt,
        string UpdatedAt);

    public record TeacherData(
        string Id,
        string Name,
        string Email,
        string? Phone,
        string Position,
        string SchoolInformation);
}

