using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using TheSampleAPI.HealthChecks;

namespace TheSampleAPI.Startup
{
    public static class HealthCheckConfig
    {
        public static void AddAllHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<RandomHealthCheck>("Random", tags: ["random"])
                .AddCheck<HealthyHealthCheck>("Healthy", tags: ["healthy"])
                .AddCheck<UnhealthHealthCheck>("Unhealthy", tags: ["unhealthy"])
                .AddCheck<DegradedHealthCheck>("Degraded", tags: ["degraded"]);


        }
        public static void MapAllHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health");
            app.MapHealthChecks("/health/healthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("healthy")
            });
            app.MapHealthChecks("/health/Unhealthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("Unhealthy")
            });
            app.MapHealthChecks("/health/Degraded", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("Degraded")
            });
            app.MapHealthChecks("/health/Random", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("Random")
            });

            app.MapHealthChecks("/health/ui", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/healthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("healthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/Unhealthy", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("Unhealthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/Degraded", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("Degraded"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/Random", new HealthCheckOptions
            {
                Predicate = x => x.Tags.Contains("Random"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
