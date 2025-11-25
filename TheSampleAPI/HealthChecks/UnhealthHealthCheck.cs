using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TheSampleAPI.HealthChecks
{
    public class UnhealthHealthCheck : IHealthCheck
    
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                HealthCheckResult.Unhealthy("This is a test Unhealthy service."));
        }

    }
}


