using barberBoss.Domain.Entities;
using barberBoss.Domain.Repository;
using barberBoss.Infrastructure.DataBaseAcess;
using Microsoft.EntityFrameworkCore;

namespace barberBoss.Infrastructure.Repository;

internal class BillingCommand : IBillingCommand
{
    private readonly BarberBossDbContext _dbContext;
    public BillingCommand(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddBilling(Billing billing, CancellationToken cancellationToken)
    {
        await _dbContext.Billings.AddAsync(billing, cancellationToken);
    }
    public void Update(Billing billing, CancellationToken cancellationToken)
    {
        _dbContext.Billings.Update(billing);
    }
    public void Delete(Billing billing, CancellationToken cancellationToken)
    {
        _dbContext.Billings.Remove(billing);
    }
}
