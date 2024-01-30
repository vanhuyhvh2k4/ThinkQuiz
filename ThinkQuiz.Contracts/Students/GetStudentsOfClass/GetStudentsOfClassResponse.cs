using System;
using System.Text.Json.Serialization;
using ThinkQuiz.Contracts.Students.Common;

namespace ThinkQuiz.Contracts.Students.GetStudentsOfClass
{
	public record GetStudentsOfClassResponse
	{
		public int Status { get; init; } = 200;

		[JsonPropertyName("data")]
		public StudentData Data { get; init; } = null!;
	}

	public record StudentData
	{
        [JsonPropertyName("students")]
        public List<StudentResponse> Students { get; init; } = null!;
    }
}

