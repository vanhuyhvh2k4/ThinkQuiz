using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Class.Common
{
    public record ClassStudentResponse
    {
        [JsonPropertyName("studentId")]
        public string StudentId { get; init; } = null!;

        [JsonPropertyName("classId")]
        public string ClassId { get; init; } = null!;

        [JsonPropertyName("status")]
        public bool Status { get; init; }
    }
}

