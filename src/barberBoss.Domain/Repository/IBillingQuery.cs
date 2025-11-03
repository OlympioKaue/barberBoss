using barberBoss.Domain.Entities;

namespace barberBoss.Domain.Repository;

public interface IBillingQuery
{
    Task<List<Billing>> GetBilling(int numberPage, int numberSize);
    Task<Billing?> GetBillingById(int id);
    Task<List<Billing>> GetBillingsWithDayofWeek(DateTime dateMonth, DateTime dateYear, int weekNumber);
}



