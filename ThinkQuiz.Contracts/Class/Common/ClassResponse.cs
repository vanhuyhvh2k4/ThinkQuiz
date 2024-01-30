using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Class.Common
{
    public record ClassResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("teacher")]
        public TeacherData Teacher { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("schoolYear")]
        public string SchoolYear { get; init; } = null!;

        [JsonPropertyName("studentQuantity")]
        public double StudentQuantity { get; init; }
    }

    public record TeacherData
    {

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; init; } = null!;

        [JsonPropertyName("phone")]
        public string Phone { get; init; } = null!;

        [JsonPropertyName("position")]
        public string Position { get; init; } = null!;

        [JsonPropertyName("schoolInformation")]
        public string SchoolInformation { get; init; } = null!;
    }
}

