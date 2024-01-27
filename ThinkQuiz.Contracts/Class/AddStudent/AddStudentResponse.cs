using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Class.AddStudent
{
    public record AddStudentResponse
    {
        public int Status { get; } = 201;

        [JsonPropertyName("data")]
        public ClassStudentData Data { get; init; } = null!;
    }

    public record ClassStudentData
    {
        [JsonPropertyName("studentId")]
        public string StudentId { get; init; } = null!;

        [JsonPropertyName("classId")]
        public string ClassId { get; init; } = null!;

        [JsonPropertyName("status")]
        public bool Status { get; init; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; init; } = null!;
    }
}

