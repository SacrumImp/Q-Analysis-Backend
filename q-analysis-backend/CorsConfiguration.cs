using Microsoft.Extensions.DependencyInjection;

namespace q_analysis_backend
{
    internal static class CorsConfiguration
	{
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                                        "http://194.87.109.22:54321/")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}

