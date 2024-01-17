using ErrorOr;

namespace ThinkQuiz.Domain.Common.Errors.User
{
    public partial class Errors
	{
		public static class UserErrors
		{
			public static Error DuplicateEmail = Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email already in use."); 
		}
	}
}

