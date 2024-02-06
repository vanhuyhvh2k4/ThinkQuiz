using System;
namespace ThinkQuiz.Application.Students.Queries.ExportStudentsList
{
	public record ExportStudentsListResult(string FileName, string ContentType, byte[] Content);
}

