using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ModuleDistributor.Dapr.Configuration;

namespace ModuleDistributor.Dapr.HealthCheck
{
    [DependsOn(typeof(DaprSecretStoreModule))]
    public class DaprHealthCheckModule : CustomModule
    {
        protected virtual void AdditionalConfiguration(ServiceContext context, IHealthChecksBuilder builder)
        {

        }

        public override void ConfigureServices(ServiceContext context)
        {
            var builder = context.Services.AddHealthChecks()
                .AddCheck("Self", () => HealthCheckResult.Healthy(), tags: new[] { "Self" })
                .AddCheck<DaprHealthCheck>("Dapr", tags: new[] { "Dapr" });
            AdditionalConfiguration(context, builder);
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.EndPoint.MapHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            });
            context.EndPoint.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
        }
    }
}