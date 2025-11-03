using barberBoss.Domain.Entities;

namespace barberBoss.Domain.Repository;

public interface IBillingCommand
{
    Task AddBilling(Billing billing, CancellationToken cancellationToken);
    void Update (Billing billing, CancellationToken cancellationToken);
    void Delete(Billing billing, CancellationToken cancellationToken);
}
