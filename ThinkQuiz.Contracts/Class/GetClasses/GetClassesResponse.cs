using System;
using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Class.GetClasses
{
    public record GetClassesResponse
    {
        public int Status { get; init; } = 200;

        [JsonPropertyName("data")]
        public ClassData Data { get; init; } = null!;
    }

    public record ClassData
    {
        [JsonPropertyName("classes")]
        public List<Classes> Classes { get; init; } = null!;
    }

    public record Classes
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

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; init; } = null!;
    }
}

