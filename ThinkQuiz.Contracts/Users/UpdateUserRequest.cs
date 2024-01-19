namespace ThinkQuiz.Contracts.Users
{
    public record UpdateUserRequest(
        string? FullName,
        DateOnly? DateOfBirth,
        string? Phone,
        bool? Gender);
}

