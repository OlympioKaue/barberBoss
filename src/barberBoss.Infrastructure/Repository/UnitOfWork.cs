using barberBoss.Domain.Repository;
using barberBoss.Infrastructure.DataBaseAcess;

namespace barberBoss.Infrastructure.Repository;

internal class UnitOfWork : IUnitOfWork
{
    private readonly BarberBossDbContext _dbContext;
    public UnitOfWork(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
