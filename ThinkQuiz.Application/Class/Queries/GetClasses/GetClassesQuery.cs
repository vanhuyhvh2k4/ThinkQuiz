using System.Runtime.Serialization;
using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Class.Common;

namespace ThinkQuiz.Application.Class.Queries.GetClasses
{
    public record GetClassesQuery(
        Guid TeacherId,
        string? Name,
        int? Page,
        int? PerPage,
        SortBy? SortBy,
        OrderBy OrderBy = OrderBy.Asc) : IRequest<ErrorOr<List<ClassResult>>>;

    public enum SortBy
    {
        [EnumMember(Value = "Name")]
        Name,
        [EnumMember(Value = "StudentQuantity")]
        StudentQuantity
    }

    public enum OrderBy
    {
        [EnumMember(Value = "Desc")]
        Desc,
        [EnumMember(Value = "Asc")]
        Asc
    }
}

