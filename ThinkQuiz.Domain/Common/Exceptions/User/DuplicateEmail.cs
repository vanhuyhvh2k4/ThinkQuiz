using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.User
{
    public static partial class Exceptions
    {
        public static Error DuplicateEmailsException = Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already in use.");
    }
}

