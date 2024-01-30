using System.Text.Json.Serialization;

namespace ThinkQuiz.Contracts.Authentication
{
    public record AuthenticationResponse
    {
        public int Status { get; init; } = 200;

        [JsonPropertyName("data")]
        public UserData Data { get; init; } = null!;
    }

    public record UserData
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("fullName")]
        public string FullName { get; init; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; init; } = null!;

        [JsonPropertyName("dateOfBirth")]
        public DateOnly? DateOfBirth { get; init; }

        [JsonPropertyName("phone")]
        public string? Phone { get; init; }

        [JsonPropertyName("lastLogin")]
        public string LastLogin { get; init; } = null!;

        [JsonPropertyName("gender")]
        public bool Gender { get; init; }

        [JsonPropertyName("isTeacher")]
        public bool IsTeacher { get; init; }

        [JsonPropertyName("token")]
        public string Token { get; init; } = null!;
    }
}