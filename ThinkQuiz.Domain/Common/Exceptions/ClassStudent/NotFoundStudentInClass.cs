using System;
using ErrorOr;

namespace ThinkQuiz.Domain.Common.Exceptions.ClassStudent
{
    public static partial class Exceptions
    {
        public static Error NotFoundStudentInClass = Error.NotFound(code: "ClassStudent.NotFoundStudentInClass", description: "Student didn't join this class.");

    }
}

