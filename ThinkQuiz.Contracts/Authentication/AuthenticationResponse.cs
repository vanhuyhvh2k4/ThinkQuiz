namespace ThinkQuiz.Contracts.Authentication
{
    public record AuthenticationResponse(
        string Id,
        string fullName,
        string Email,
        string dateOfBirth,
        string Phone,
        DateTime LastLogin,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        bool Gender,
        string Token);
}

