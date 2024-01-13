using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleDistributor.EntityFrameworkCore;

namespace ELibrary.EntityFrameworkCore
{
    internal class ApplicationOptionsActions : OptionsActionWrapper
    {
        public override Action<IServiceProvider, DbContextOptionsBuilder>? OptionsAction 
            => (provider, options)
                => options.UseSqlServer(provider.GetRequiredService<IConfiguration>().GetConnectionString("ELibrary"))
                    .UseLazyLoadingProxies();
    }
}
