using System.Text.Json.Serialization;
using ThinkQuiz.Contracts.Class.Common;

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
        public List<ClassResponse> Classes { get; init; } = null!;
    }
}

