using ELibrary.EntityFrameworkCore;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using ModuleDistributor;
using ModuleDistributor.Grpc;

namespace ELibrary.Services
{
    [DependsOn(typeof(ELibraryEntityFrameworkCoreModule),
        typeof(GrpcServiceModule<ELibraryServicesModule>))]
    public class ELibraryServicesModule : CustomModule
    {
        public static readonly Empty Empty = new Empty();
        public override void ConfigureServices(ServiceContext context)
        {
            context.Services.AddAutoMapper(typeof(ELibraryProfile));
        }
    }
}
