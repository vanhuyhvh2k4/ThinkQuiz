using ThinkQuiz.Application.Common.Interfaces.Services.Bcrypt;
using BcryptNet = BCrypt.Net.BCrypt;

namespace ThinkQuiz.Infrashstructure.Services.Bcrypt
{
    public class BcryptHashPassword : IBcryptHashPassword
	{
        public string HashPassword(string password)
        {
            string hashedPassword = BcryptNet.HashPassword(password.Trim(), BcryptNet.GenerateSalt(10));
            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            bool isPasswordCorrect = BcryptNet.Verify(password.Trim(), hashedPassword.Trim());
            return isPasswordCorrect;
        }
    }
}

