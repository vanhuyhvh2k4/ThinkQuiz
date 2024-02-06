using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Common
{
    public record DeleteResponse
    {
        public int Status { get; init; } = 200;

        [JsonPropertyName("data")]
        public string Data { get; init; } = null!;
    }
}

