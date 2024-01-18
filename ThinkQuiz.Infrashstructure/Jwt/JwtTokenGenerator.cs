using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThinkQuiz.Application.Common.Interfaces.Jwt;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Jwt
{
    public class JwtTokenGenerator : IJwtTokenGenerator
	{
        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("think-quiz-api-super-secret-key-token")),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()!),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
               issuer: "ThinkQuiz",
               audience: "ThinkQuiz",
               expires: DateTime.UtcNow.AddMinutes(60),
               claims: claims,
               signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}

