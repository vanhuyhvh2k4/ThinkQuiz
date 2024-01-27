using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Student
{
    public static partial class Exceptions
    {
        public static Error NotFoundStudent = Error.NotFound(code: "Student.NotFound", description: "Not found any student.");

    }
}

