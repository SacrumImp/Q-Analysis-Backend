using Microsoft.Extensions.DependencyInjection;

namespace q_analysis_backend.Providers
{
	internal static class ProvidersConfiguration
	{
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IQAnalysisProvider, QAnalysisProvider>();

            return services;
        }
	}
}

