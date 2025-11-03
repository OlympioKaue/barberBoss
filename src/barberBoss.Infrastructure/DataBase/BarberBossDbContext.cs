using barberBoss.Domain.Entities;
using barberBoss.Infrastructure.DataBase.ConfigurationsEntities;
using Microsoft.EntityFrameworkCore;

namespace barberBoss.Infrastructure.DataBaseAcess;

internal class BarberBossDbContext : DbContext
{
    public BarberBossDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }
    public DbSet<Billing> Billings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BarberBossBillings());
    }

}
