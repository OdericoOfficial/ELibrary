using HealthChecks.Fronted.Shared;
using ModuleDistributor;
using ModuleDistributor.Dapr.Configuration;
using ModuleDistributor.Dapr.HealthCheck;

namespace HealthChecks.Fronted
{
    [DependsOn(typeof(DaprSecretStoreModule))]
    public class HealthChecksFrontedModule : DaprHealthCheckModule
    {
        protected override void AdditionalConfiguration(ServiceContext context, IHealthChecksBuilder builder)
        {
            builder.AddCheck<IdentitiesHealthCheck>("Identities", tags: new[] { "Identities" });
            builder.AddCheck<ELibraryHealthCheck>("ELibrary", tags: new[] { "ELibrary" });
            builder.AddSqlServer(context.Configuration.GetConnectionString("HealthChecks")!, name: "HealthCheckStorage", tags: new[] { "SqlServer" } );
            builder.AddSqlServer(context.Configuration.GetConnectionString("Identities")!, name: "IdentitiesStorage", tags: new[] { "SqlServer" });
            builder.AddSqlServer(context.Configuration.GetConnectionString("ELibrary")!, name: "ELibraryStorage", tags: new[] { "SqlServer" });
            builder.AddRedis("redis", name: "Redis", tags: new[] { "Redis" } );
        }

        public override void ConfigureServices(ServiceContext context)
        {
            base.ConfigureServices(context);
            context.Services.AddHealthChecksUI()
                .AddSqlServerStorage(context.Configuration.GetConnectionString("HealthChecks")!);
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            base.OnApplicationInitialization(context);
            context.App.UseHealthChecksUI();
            context.EndPoint.MapHealthChecksUI();
            context.EndPoint.Map("/", () => Results.LocalRedirect("~/healthchecks-ui"));
        }
    }
}
