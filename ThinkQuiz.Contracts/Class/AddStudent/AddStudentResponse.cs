using System.Text.Json.Serialization;
using ThinkQuiz.Contracts.Class.Common;

namespace ThinkQuiz.Contracts.Class.AddStudent
{
    public record AddStudentResponse
    {
        public int Status { get; } = 201;

        [JsonPropertyName("data")]
        public ClassStudentResponse Data { get; init; } = null!;
    }
}

