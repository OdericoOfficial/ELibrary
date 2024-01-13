using Microsoft.EntityFrameworkCore;
using ModuleDistributor.EntityFrameworkCore;

namespace Identities.API.EntityFrameworkCore
{
    internal class ApplicationOptionsAction : OptionsActionWrapper
    {
        public override Action<IServiceProvider, DbContextOptionsBuilder>? OptionsAction
            => (provider, options)
                => options.UseSqlServer(provider.GetRequiredService<IConfiguration>().GetConnectionString("Identities"))
                    .UseLazyLoadingProxies();
    }
}
