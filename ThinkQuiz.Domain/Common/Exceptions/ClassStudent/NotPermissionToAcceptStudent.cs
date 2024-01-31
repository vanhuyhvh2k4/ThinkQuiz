using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.ClassStudent
{
    public static partial class Exceptions
    {
        public static Error NotPermissionToAcceptStudent = Error.Unauthorized(code: "ClassStudent.NotPermissionToAcceptStudent", description: "Don't have permission to accept student.");

    }
}

