using System;
using ThinkQuiz.Domain.StudeæntAggregate;
using ThinkQuiz.Domain.TeacherAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Services.Jwt
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, Teacher? teacher, Student? student);
    }
}

