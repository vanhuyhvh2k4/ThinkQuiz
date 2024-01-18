using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ThinkQuiz.Application.Common.Interfaces.Jwt;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Infrashstructure.Jwt;
using ThinkQuiz.Infrashstructure.Persistence.Repositories;

namespace ThinkQuiz.Infrashstructure
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrashstructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddAuth(configuration);

			services.AddScoped<IUserRepository, UserRepository>();


			return services;
		}

		public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
		{
			var jwtSettings = new JwtSettings();

			configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(
                defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
		}
	}
}

