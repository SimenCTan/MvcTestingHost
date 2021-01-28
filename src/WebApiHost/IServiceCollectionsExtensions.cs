using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GrpcService;
using System;

namespace WebApiHost
{
    public static class IServiceCollectionsExtensions
    {
        public static IServiceCollection AddGrpcService(this IServiceCollection services, IConfiguration configuration)
        {
            var address = configuration.GetValue<string>("greetergrpc");
            services.AddGrpcClient<Greeter.GreeterClient>(o =>
            {
                o.Address = new Uri("http://localhost:42002");
            });
            // .AddInterceptor(() => new LoggingInterceptor());
            return services;
        }
    }
}
