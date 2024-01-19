using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.User
{
    public static partial class Exceptions
	{
        public static Error NotFoundUser = Error.NotFound(
            code: "User.NotFound",
            description: "Not found any user.");
    }
}

