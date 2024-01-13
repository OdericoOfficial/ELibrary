using Blazored.LocalStorage;
using ELibrary.Fronted.Components;
using ELibrary.Protos;
using HealthChecks.Fronted.Shared;
using Identities.Protos;
using Identities.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ModuleDistributor;
using ModuleDistributor.Dapr.Configuration;
using ModuleDistributor.Dapr.HealthCheck;
using ModuleDistributor.Serilog;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ELibrary.Fronted
{
    [DependsOn(typeof(DaprSecretStoreModule),
        typeof(SerilogModule))]
    public class ELibraryFrontedModule : DaprHealthCheckModule
    {
        private static readonly Uri _elibrary = new Uri("http://elibrary-api");
        private static readonly Uri _identities = new Uri("http://identities-api");

        protected override void AdditionalConfiguration(ServiceContext context, IHealthChecksBuilder builder)
        {
            builder.AddCheck<IdentitiesHealthCheck>("Identities", tags: new[] { "Identities" });
            builder.AddCheck<ELibraryHealthCheck>("ELibrary", tags: new[] { "ELibrary" });
        }

        public override void ConfigureServices(ServiceContext context)
        {
            base.ConfigureServices(context);
            
            context.Services.AddGrpcClient<TestELibrary.TestELibraryClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<Book.BookClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<CollectedBook.CollectedBookClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<Collection.CollectionClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<Comment.CommentClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<Protos.File.FileClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<Score.ScoreClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<SearchBook.SearchBookClient>(options => options.Address = _elibrary);
            context.Services.AddGrpcClient<TestIdentities.TestIdentitiesClient>(options => options.Address = _identities);
            context.Services.AddGrpcClient<Captcha.CaptchaClient>(options => options.Address = _identities);
            context.Services.AddGrpcClient<Authentication.AuthenticationClient>(options => options.Address = _identities);

            context.Services.AddBlazoredLocalStorage(options =>
            {
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                options.JsonSerializerOptions.WriteIndented = false;
            });
            context.Services.AddBlazorDownloadFile();
            context.Services.AddAutoMapper(typeof(ELibraryFrontedProfile));
            context.Services.AddMasaBlazor();
            context.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            base.OnApplicationInitialization(context);

            if (!context.Environment.IsDevelopment())
                context.App.UseExceptionHandler("/Error");

            context.App.UseStaticFiles();
            context.App.UseAntiforgery();

            context.EndPoint.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
        }
    }
}
