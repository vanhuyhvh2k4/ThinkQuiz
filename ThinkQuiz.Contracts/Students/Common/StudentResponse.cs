using System;
using System.Text.Json.Serialization;
using ThinkQuiz.Contracts.Class.Common;

namespace ThinkQuiz.Contracts.Students.Common
{
	public record StudentResponse
	{
        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("fullName")]
        public string FullName { get; init; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; init; } = null!;

        [JsonPropertyName("phone")]
        public string? Phone { get; init; }

        [JsonPropertyName("gender")]
        public bool Gender { get; init; }

        [JsonPropertyName("dateOfBirth")]
        public string? DateOfBirth { get; init; }

        [JsonPropertyName("lastLogin")]
        public string LastLogin { get; init; } = null!;
    };
}

