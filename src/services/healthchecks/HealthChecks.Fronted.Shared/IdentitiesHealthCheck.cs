using Grpc.Health.V1;
using Grpc.Net.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Fronted.Shared
{
    public class IdentitiesHealthCheck : IHealthCheck
    {
        private static readonly GrpcChannel _channel = GrpcChannel.ForAddress("http://identities-api");
        private readonly Health.HealthClient _client;

        public IdentitiesHealthCheck()
        {
            _client = new Health.HealthClient(_channel);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _client.CheckAsync(new HealthCheckRequest { Service = "" });

                if (response.Status == HealthCheckResponse.Types.ServingStatus.Serving)
                    return HealthCheckResult.Healthy("Identities is healthy.");
                return new HealthCheckResult(context.Registration.FailureStatus,
                    "Identities is unhealthy.");
            }
            catch (Exception ex) 
            {
                return new HealthCheckResult(context.Registration.FailureStatus,
                    $"Identities: {ex.Message}");
            }
        }
    }
}
