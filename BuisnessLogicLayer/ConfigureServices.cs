using BuisnessLogicLayer.ProductsService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuisnessLogicLayer
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBuisnessLogicLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
