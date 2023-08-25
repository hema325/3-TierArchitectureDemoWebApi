using DataAccessLayer.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
