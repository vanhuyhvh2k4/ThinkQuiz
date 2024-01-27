using System;
using System.Runtime.Serialization;

namespace ThinkQuiz.Contracts.Class.GetClasses
{
	public record GetClassesRequest(int? Page, int? PerPage, SortBy? SortBy, OrderBy OrderBy = OrderBy.Asc);

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

