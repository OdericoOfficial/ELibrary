using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDistributor.Grpc
{
    [DependsOn(typeof(GrpcModule))]
    public class GrpcWebServiceModule<TEntryModule> : CustomModule
        where TEntryModule : CustomModule
    {
        public override void OnApplicationInitialization(ApplicationContext context)
        {
            context.App.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            Assembly assembly = typeof(TEntryModule).Assembly;
            List<Expression> list = new List<Expression>();
            List<ParameterExpression> variables = new List<ParameterExpression>();
            var param = Expression.Parameter(typeof(IEndpointRouteBuilder));
            var map = GetType().GetMethod("MapGrpcWebServiec", BindingFlags.Public | BindingFlags.Static);

            if (map is null)
                throw new ArgumentNullException(nameof(map));

            foreach (var item in assembly.GetTypes())
                if (item.GetCustomAttribute<GrpcServiceAttribute>() is not null)
                {
                    var temp = map.MakeGenericMethod(item);
                    list.Add(Expression.Call(temp, param));
                }

            Expression.Lambda<Action<IEndpointRouteBuilder>>(Expression.Block(list), param)
                .Compile()
                .Invoke(context.EndPoint);
        }

        public static void MapGrpcWebServiec<TService>(IEndpointRouteBuilder endPoint) where TService : class
            => endPoint.MapGrpcService<TService>()
                .EnableGrpcWeb();
    }
}
