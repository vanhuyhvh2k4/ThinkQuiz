﻿using System.Text.Json.Serialization;

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
        public string? Id { get; init; }

        [JsonPropertyName("fullName")]
        public string? FullName { get; init; }

        [JsonPropertyName("email")]
        public string? Email { get; init; }

        [JsonPropertyName("dateOfBirth")]
        public DateOnly? DateOfBirth { get; init; }

        [JsonPropertyName("phone")]
        public string? Phone { get; init; }

        [JsonPropertyName("lastLogin")]
        public string? LastLogin { get; init; }

        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; init; }

        [JsonPropertyName("updatedAt")]
        public string? UpdatedAt { get; init; }

        [JsonPropertyName("gender")]
        public bool Gender { get; init; }

        [JsonPropertyName("isTeacher")]
        public bool IsTeacher { get; init; }

        [JsonPropertyName("token")]
        public string? Token { get; init; }
    }
}