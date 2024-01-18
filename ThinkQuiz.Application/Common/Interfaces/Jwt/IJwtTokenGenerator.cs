using System;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Application.Common.Interfaces.Jwt
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(User user);
	}
}

