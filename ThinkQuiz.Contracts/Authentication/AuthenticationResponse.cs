﻿namespace ThinkQuiz.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string FullName,
        string Email,
        string DateOfBirth,
        string Phone,
        DateTime LastLogin,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        bool Gender,
        string Token);
}

