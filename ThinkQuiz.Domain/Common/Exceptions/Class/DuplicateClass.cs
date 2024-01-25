using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Class
{
    public static partial class Exceptions
	{
		public static Error DuplicateClass = Error.Conflict(code: "Class.Duplicate", description: "Class already exists.");
		
	}
}

