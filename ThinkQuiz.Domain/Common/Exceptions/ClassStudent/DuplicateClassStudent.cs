using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.ClassStudent
{
    public static partial class Exceptions
    {
        public static Error DuplicateClassStudent = Error.Conflict(code: "ClassStudent.Duplicate", description: "ClassStudent already exists.");

    }
}

