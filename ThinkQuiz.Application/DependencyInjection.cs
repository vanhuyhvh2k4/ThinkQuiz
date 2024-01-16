using Microsoft.Extensions.DependencyInjection;

namespace ThinkQuiz.Application
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			return services;
		}
	}
}

