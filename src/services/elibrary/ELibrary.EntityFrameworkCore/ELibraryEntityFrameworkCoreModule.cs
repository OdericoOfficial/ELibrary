using Microsoft.Extensions.DependencyInjection;
using ModuleDistributor;
using ModuleDistributor.EntityFrameworkCore;

namespace ELibrary.EntityFrameworkCore
{
    [DependsOn(typeof(EntityFrameworkCoreModule<ApplicationDbContext, ApplicationOptionsActions>))]
    public class ELibraryEntityFrameworkCoreModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
        {
            context.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public override async ValueTask OnApplicationInitializationAsync(ApplicationContext context)
        {
            using var scope = context.App.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
