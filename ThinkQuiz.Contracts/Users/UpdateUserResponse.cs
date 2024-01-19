namespace ThinkQuiz.Contracts.Users
{
    public record UpdateUserResponse(
        Guid Id,
        string FullName,
        string Email,
        DateOnly DateOfBirth,
        string Phone,
        DateTime LastLogin,
        DateTime CreatedAt,
        DateTime UpdatedAt,
        bool Gender);
	
}

