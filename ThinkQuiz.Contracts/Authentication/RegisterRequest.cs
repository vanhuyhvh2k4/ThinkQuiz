
namespace ThinkQuiz.Contracts.Authentication
{
    public record RegisterRequest(string FullName, string Password, string Email, string ConfirmPassword);
}

