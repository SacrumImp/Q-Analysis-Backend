using System;
using Microsoft.Extensions.DependencyInjection;
using q_analysis_backend.Providers;

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
                                        "http://77.37.180.248:54321")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}

