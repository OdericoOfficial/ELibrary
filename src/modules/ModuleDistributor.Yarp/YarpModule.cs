using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ModuleDistributor.Yarp
{
    public class YarpModule : CustomModule
    {
        public override void ConfigureServices(ServiceContext context)
        {
            context.Services.AddReverseProxy()
                .LoadFromConfig(context.Configuration.GetSection("ReverseProxy"));
        }

        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.EndPoint.MapReverseProxy();
        }
    }
}
