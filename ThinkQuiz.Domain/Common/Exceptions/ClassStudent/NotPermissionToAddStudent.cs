﻿using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.ClassStudent
{
    public static partial class Exceptions
    {
        public static Error NotPermissionToAddStudent = Error.Unauthorized(code: "ClassStudent.NotPermissionToAddStudent", description: "Don't have permission to add student.");

    }
}

