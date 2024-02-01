using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Teacher
{
    public static partial class Exceptions
    {
        public static Error NotFoundTeacher = Error.NotFound(
            code: "Teacher.NotFound",
            description: "Not found any teacher.");
    }
}

