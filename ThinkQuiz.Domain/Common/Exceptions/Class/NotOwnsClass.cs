using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Class
{
    public static partial class Exceptions
    {
        public static Error NotOwnsClass = Error.NotFound(code: "Class.NotOwnsClass", description: "You not owns this class.");

    }
}

