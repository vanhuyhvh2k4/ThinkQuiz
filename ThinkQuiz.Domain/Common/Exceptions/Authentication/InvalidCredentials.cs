using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Authentication
{
	public static partial class Exceptions
	{
        public static Error InvalidCredentials = Error.Validation(
            code: "Authentication.InvalidCredentials",
            description: "Invalid credentials.");
    }
}

