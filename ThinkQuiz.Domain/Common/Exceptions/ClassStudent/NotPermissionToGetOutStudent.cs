using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.ClassStudent
{
    public static partial class Exceptions
    {
        public static Error NotPermissionToGetOutStudent = Error.Unauthorized(code: "ClassStudent.NotPermissionToGetOutStudent", description: "Don't have permission to get out student.");

    }
}

