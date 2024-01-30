using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Class.Create
{
    public record CreateClassResponse
    {
        public int Status { get; init; } = 201;

        [JsonPropertyName("data")]
        public ClassData Data { get; init; } = null!;
    }

    public record ClassData
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("teacherId")]
        public string TeacherId { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("schoolYear")]
        public string SchoolYear { get; init; } = null!;

        [JsonPropertyName("studentQuantity")]
        public double StudentQuantity { get; init; }
    }
}

