namespace ThinkQuiz.Contracts.Authentication
{
    public record AuthenticationResponse(
        string fullName,
        string Email,
        string dateOfBirth,
        string Phone,
        DateTime LastLogin,
        bool Gender,
        string Token);
}

