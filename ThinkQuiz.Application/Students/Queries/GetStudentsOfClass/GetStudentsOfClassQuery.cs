using System.Runtime.Serialization;
using ErrorOr;
using MediatR;
using ThinkQuiz.Domain.StudentAggregate;

namespace ThinkQuiz.Application.Students.Queries.GetStudentsOfClass
{
	public record GetStudentsOfClassQuery(
        Guid TeacherId,
        Guid ClassId,
        string? FullName,
        string? Email,
        int? Page,
        int? PerPage,
        SortBy? SortBy,
        OrderBy OrderBy = OrderBy.Asc,
        bool Status = true) : IRequest<ErrorOr<List<Student>>>;

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

