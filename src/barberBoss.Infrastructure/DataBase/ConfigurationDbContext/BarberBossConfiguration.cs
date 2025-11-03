using Microsoft.EntityFrameworkCore;

namespace barberBoss.Infrastructure.DataBase.ConfigurationDbContext;

//Centralizando a configuração do banco de dados.
internal static class BarberBossConfiguration
{
    public static void ConfigureProvider(this DbContextOptionsBuilder builder, string connectionString)
    {
        var version = new MySqlServerVersion(new Version(8, 0, 41));
        builder.UseMySql(connectionString, version);  
    }
}
