using barberBoss.Infrastructure.DataBaseAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace barberBoss.Infrastructure.ConfigurationMigrations;

public static class BarberBossMigrations
{
    public static async Task MigrateDataBase(IServiceProvider service)
    {
        {
            var dbcontext = service.GetRequiredService<BarberBossDbContext>();
            await dbcontext.Database.MigrateAsync();
        }
    }
}
