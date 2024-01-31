using System;
using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Class.GetOutStudent
{
	public record GetOutStudentResponse
	{
		public int Status { get; init; } = 200;

		[JsonPropertyName("data")]
		public object Data { get; init; } = new {};
	}
}

