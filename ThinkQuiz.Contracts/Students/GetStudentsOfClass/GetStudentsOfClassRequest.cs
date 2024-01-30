using System.Runtime.Serialization;

namespace ThinkQuiz.Contracts.Students.GetStudentsOfClass
{
    public record GetStudentsOfClassRequest(
        string? FullName,
        string? Email,
        int? Page,
        int? PerPage,
        SortBy? SortBy,
        OrderBy OrderBy = OrderBy.Asc,
        bool Status = true);

    public enum SortBy
    {
        [EnumMember(Value = "FullName")]
        FullName,
        [EnumMember(Value = "Email")]
        Email
    }

    public enum OrderBy
    {
        [EnumMember(Value = "Desc")]
        Desc,
        [EnumMember(Value = "Asc")]
        Asc
    }
}

