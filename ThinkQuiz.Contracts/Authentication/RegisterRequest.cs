
namespace ThinkQuiz.Contracts.Authentication
{
    public record RegisterRequest(
        string FullName,
        string Password,
        string Email,
        string ConfirmPassword,
        RegisterType RegisterType,
        string? Position,
        string? SchoolInformation);

    public enum RegisterType
    {
        Student = 0,
        Teacher = 1
    }
}

