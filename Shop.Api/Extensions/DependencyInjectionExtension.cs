using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Context;
using Shop.Domain.Handlers;
using Shop.Domain.Repositories;
using Shop.Infra.Data;
using Shop.Infra.Data.Repositories;

namespace Shop.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductHandler, ProductHandler>();
            return services;
        }
    }
}