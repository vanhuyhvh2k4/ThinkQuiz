using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.ClassStudent
{
    public static partial class Exceptions
    {
        public static Error DuplicateClassStudent = Error.Conflict(code: "ClassStudent.Duplicate", description: "Student already exists in this class.");

    }
}

