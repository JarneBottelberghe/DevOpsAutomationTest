using Services.Orders;
using Services.Products;
using Shared.Orders;
using Shared.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all services to the DI container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //services.AddScoped<IProductService, FakeProductService>();
        services.AddScoped<IOrderService, FakeOrderService>();
        services.AddScoped<IProductService, FakeProductService>();
        // Add more services here...

        return services;
    }
}

