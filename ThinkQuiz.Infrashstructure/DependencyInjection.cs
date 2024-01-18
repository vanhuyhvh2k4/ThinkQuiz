using Microsoft.Extensions.DependencyInjection;
using ThinkQuiz.Application.Common.Interfaces.Jwt;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Infrashstructure.Jwt;
using ThinkQuiz.Infrashstructure.Persistence.Repositories;

namespace ThinkQuiz.Infrashstructure
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrashstructure(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();

			services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

			return services;
		}
	}
}

