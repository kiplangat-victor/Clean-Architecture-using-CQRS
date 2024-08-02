using CleanArchWithCQRSandMediator.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchWithCQRSandMediator.Infra
{
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(options =>
        options.UseMySql(configuration.GetConnectionString("AppDefaultConnectionString"),new MySqlServerVersion(new Version(8,0,21)))
        );
        services.AddTransient<IBlogRepository,BlogRepository>();

        return services;
    }

}
}