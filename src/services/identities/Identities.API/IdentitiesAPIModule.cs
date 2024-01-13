using Google.Protobuf.WellKnownTypes;
using Identities.API.EntityFrameworkCore;
using Identities.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ModuleDistributor;
using ModuleDistributor.Dapr.Configuration;
using ModuleDistributor.Dapr.GrpcHealthChecks;
using ModuleDistributor.EntityFrameworkCore;
using ModuleDistributor.Grpc;
using ModuleDistributor.Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Identities.API
{
    [DependsOn(typeof(DaprSecretStoreModule),
        typeof(SerilogModule),
        typeof(EntityFrameworkCoreModule<ApplicationDbContext, ApplicationOptionsAction>),
        typeof(GrpcServiceModule<IdentitiesAPIModule>))]
    internal class IdentitiesAPIModule : DaprGrpcHealthCheckModule
    {
        public static readonly Empty Empty = new Empty();

        protected override void AdditionalConfiguration(ServiceContext context, IHealthChecksBuilder builder)
            => builder.AddSqlServer(context.Configuration.GetConnectionString("Identities")!);

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

            section = context.Configuration.GetSection(nameof(EmailOptions));
            EmailOptions emailOptions = new EmailOptions();
            section.Bind(emailOptions);
            context.Services.AddScoped(provider =>
            {
                var smtp = new SmtpClient();
                smtp.Port = Convert.ToInt32(emailOptions.Port);
                smtp.Host = emailOptions.ServerAddress;
                smtp.Credentials = new NetworkCredential(emailOptions.SenderId, emailOptions.AuthenticationToken);
                return smtp;
            });

            context.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }


        public override async ValueTask OnApplicationInitializationAsync(ApplicationContext context)
        {
            context.App.UseAuthentication();
            context.App.UseAuthorization();

            base.OnApplicationInitialization(context);

            using var scope = context.App.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var result = await roleManager.CreateAsync(new IdentityRole
                {   
                    Name = "User"
                });
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var user = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "TestElibrary@elibrary.com"
            };
            result = await userManager.CreateAsync(user, "Tt#741852");
            result = await userManager.AddToRoleAsync(user, "User");
            result = await userManager.AddClaimsAsync(user,
                (await userManager.GetRolesAsync(user))
                    .Select(item => new Claim(ClaimTypes.Role, item))
                    .Union(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                    }));
        }
    }
}
