namespace barberBoss.Domain.Repository;

public interface IUnitOfWork
{
    Task SaveChanges(CancellationToken cancellationToken);
}
