using System.Text.Json.Serialization;
using ThinkQuiz.Contracts.Class.Common;

namespace ThinkQuiz.Contracts.Class.AcceptStudent
{
    public record AcceptStudentResponse
	{
		public int Status { get; } = 200;

		[JsonPropertyName("data")]
		public ClassStudentResponse Data { get; init; } = null!;
	}
}

