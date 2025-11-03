using barberBoss.Domain.Repository;
using barberBoss.Infrastructure.DataBase.ConfigurationDbContext;
using barberBoss.Infrastructure.DataBaseAcess;
using barberBoss.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace barberBoss.Infrastructure.Extension;

public static class BarberBossExtension
{
    public static void AddInfrastructureExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDataBase(services, configuration );
    }
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBillingCommand, BillingCommand>();
        services.AddScoped<IBillingQuery, BillingQuery>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    private static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BarberBossDbContext>(option =>
        {
            option.ConfigureProvider(connectionString!);
        });
    }
}
