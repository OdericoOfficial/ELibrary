using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ModuleDistributor.Dapr.Configuration;
using ModuleDistributor.Dapr.HealthCheck;

namespace ModuleDistributor.Dapr.GrpcHealthChecks
{
    [DependsOn(typeof(DaprSecretStoreModule))]
    public class DaprGrpcHealthCheckModule : CustomModule
    {
        protected virtual void AdditionalConfiguration(ServiceContext context, IHealthChecksBuilder builder)
        {

        }

        public override void ConfigureServices(ServiceContext context)
        {
            var builder = context.Services.AddGrpcHealthChecks()
                .AddCheck("Self", () => HealthCheckResult.Healthy(), tags: new[] { "Self" })
                .AddCheck<DaprHealthCheck>("Dapr", tags: new[] { "Dapr" });
            AdditionalConfiguration(context, builder);
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.EndPoint.MapGrpcHealthChecksService();
        }
    }
}
