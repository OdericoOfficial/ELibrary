using ELibrary.Services;
using Identities.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ModuleDistributor;
using ModuleDistributor.Dapr.Configuration;
using ModuleDistributor.Dapr.GrpcHealthChecks;
using ModuleDistributor.Serilog;
using System.Text;

namespace ELibrary.API
{
    [DependsOn(typeof(DaprSecretStoreModule),
        typeof(SerilogModule),
        typeof(ELibraryServicesModule))]
    public class ELibraryAPIModule : DaprGrpcHealthCheckModule
    {
        protected override void AdditionalConfiguration(ServiceContext context, IHealthChecksBuilder builder)
            => builder.AddSqlServer(context.Configuration.GetConnectionString("ELibrary")!);

        public override void ConfigureServices(ServiceContext context)
        {
            base.ConfigureServices(context);

            var section = context.Configuration.GetSection(nameof(JwtTokenOptions));
            JwtTokenOptions tokenOptions = new JwtTokenOptions();
            section.Bind(tokenOptions);
            context.Services.Configure<JwtTokenOptions>(section);
            context.Services
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key!))
                    };
                });
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.App.UseAuthentication();
            context.App.UseAuthorization();

            base.OnApplicationInitialization(context);
        }
    }
}
