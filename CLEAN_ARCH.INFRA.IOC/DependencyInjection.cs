using CLEAN_ARCH.DOMAIN.Interfaces;
using CLEAN_ARCH.INFRA.DATA.Context;
using CLEAN_ARCH.INFRA.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLEAN_ARCH.INFRA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CleanArchDbConnectionString"),
                    m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();

            return service;
        }
    }
}
