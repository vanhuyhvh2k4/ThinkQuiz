using System;
namespace ThinkQuiz.Contracts.Class.GetOutStudent
{
	public record GetOutStudentRequest(Guid StudentId, Guid ClassId);
}

