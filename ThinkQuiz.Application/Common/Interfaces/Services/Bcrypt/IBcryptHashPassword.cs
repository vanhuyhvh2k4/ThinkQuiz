using System;
namespace ThinkQuiz.Application.Common.Interfaces.Services.Bcrypt
{
	public interface IBcryptHashPassword
	{
		string HashPassword(string password);

		bool VerifyPassword(string password, string hashedPassword);
	}
}

