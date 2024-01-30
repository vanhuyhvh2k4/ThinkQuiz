using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.Student
{
    public static partial class Exceptions
    {
        public static Error NotPermissionToGetStudents = Error.Unauthorized(code: "Student.NotPermission", description: "Don't have permission to this action.");

    }
}

