using System.Text.Json.Serialization;
using ThinkQuiz.Contracts.Class.Common;

namespace ThinkQuiz.Contracts.Class.GetClass
{
    public record GetClassResponse
    {
        public int Status { get; init; } = 200;

        [JsonPropertyName("data")]
        public ClassResponse Class { get; init; } = null!;
    }
}

