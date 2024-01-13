using Grpc.Health.V1;
using Grpc.Net.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Fronted.Shared
{
    public class ELibraryHealthCheck : IHealthCheck
    {
        private static readonly GrpcChannel _channel = GrpcChannel.ForAddress("http://elibrary-api");
        private readonly Health.HealthClient _client;

        public ELibraryHealthCheck()
        {
            _client = new Health.HealthClient(_channel);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _client.CheckAsync(new HealthCheckRequest { Service = "" });

                if (response.Status == HealthCheckResponse.Types.ServingStatus.Serving)
                    return HealthCheckResult.Healthy("ELibrary is healthy.");
                return new HealthCheckResult(context.Registration.FailureStatus,
                    "ELibrary is unhealthy.");
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, $"ELibrary: {ex.Message}");
            }
        }
    }
}
