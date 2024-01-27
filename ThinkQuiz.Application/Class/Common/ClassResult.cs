using System;
namespace ThinkQuiz.Application.Class.Common
{
	public record ClassResult(
        string Id,
        string TeacherId,
        string Name,
        string SchoolYear,
        double StudentQuantity,
        string CreatedAt,
        string UpdatedAt);
}

