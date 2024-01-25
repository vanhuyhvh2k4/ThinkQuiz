using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Infrashstructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ThinkQuiz.Infrashstructure.Persistence;
using ThinkQuiz.Infrashstructure.Services.Jwt;
using ThinkQuiz.Application.Common.Interfaces.Services.Jwt;
using ThinkQuiz.Application.Common.Interfaces.Services.Bcrypt;
using ThinkQuiz.Infrashstructure.Services.Bcrypt;

namespace ThinkQuiz.Infrashstructure
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrashstructure(this IServiceCollection services, ConfigurationManager configuration)
		{
            services.AddDbContext<ThinkQuizDbContext>(options => options.UseMySql(configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(10, 4, 25))));

            services.AddAuth(configuration)
                .AddPersistence();

            services.AddSingleton<IBcryptHashPassword, BcryptHashPassword>();

			return services;
		}

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();

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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Teacher", policy =>
                {
                    policy.RequireClaim("teacherId");
                });

                options.AddPolicy("Student", policy =>
                {
                    policy.RequireClaim("studentId");
                });
            });

            return services;
		}
	}
}

