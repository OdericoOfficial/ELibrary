using ELibrary.Protos;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Identities.Protos;
using Microsoft.Extensions.DependencyInjection;

namespace ELibrary.Fronted.Shared
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddGrpcWebServices(this IServiceCollection services)
        {
            return services.AddELibraryService<TestELibrary.TestELibraryClient>();
        }

        public static IServiceCollection AddGrpcWebServicesInAssembly(this IServiceCollection services)
        {
            return services.AddELibraryServiceInAssembly<TestELibrary.TestELibraryClient>();
        }

        private static IServiceCollection AddELibraryService<TClient>(this IServiceCollection services)
            where TClient : class
        {
            services.AddGrpcClient<TClient>(factory => factory.Address = new Uri("http://elibrary-api"));
            return services;
        }

        private static IServiceCollection AddIdentitiesService<TClient>(this IServiceCollection services)
            where TClient : class
        {
            services.AddGrpcClient<TClient>(factory => factory.Address = new Uri("http://identities-api"));
            return services;
        }
    }
}
