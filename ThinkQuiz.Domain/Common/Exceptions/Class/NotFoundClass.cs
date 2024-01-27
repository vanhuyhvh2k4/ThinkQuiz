using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Class
{
    public static partial class Exceptions
    {
        public static Error NotFoundClass = Error.NotFound(code: "Class.NotFound", description: "Not found any classes.");

    }
}

