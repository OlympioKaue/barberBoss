using barberBoss.Domain.Entities;
using barberBoss.Domain.Repository;
using barberBoss.Infrastructure.DataBaseAcess;
using Microsoft.EntityFrameworkCore;

namespace barberBoss.Infrastructure.Repository;

internal class BillingQuery : IBillingQuery
{
    private readonly BarberBossDbContext _dbContext;
    public BillingQuery(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Billing>> GetBilling(int numberPage, int numberSize)
    {
        return await _dbContext.Billings
            .AsNoTracking()
            .OrderBy(x => x.IdBilling)
            .Skip((numberPage - 1) * numberSize)
            .Take(numberSize)
            .ToListAsync();
    }

    public async Task<Billing?> GetBillingById(int id)
    {
        return await _dbContext.Billings
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IdBilling == id);
    }

    public async Task<List<Billing>> GetBillingsWithDayofWeek(DateTime dateMonth, DateTime dateYear, int weekNumber)
    {
        var weeks = new List<(DateTime start, DateTime end)>();
        var startDayMonthYear = dateMonth;

        while (startDayMonthYear <= dateYear)
        {
            var dayIncrement = startDayMonthYear.AddDays(6);

            if (dayIncrement > dateYear)
            {
                dayIncrement = dateYear;
            }

            weeks.Add((startDayMonthYear, dayIncrement));
            startDayMonthYear = dayIncrement.AddDays(1);
        }

        var (start, end) = weeks[weekNumber - 1];

        return await _dbContext.Billings
             .Where(x => x.CreatedAt.Date >= start.Date && x.CreatedAt.Date <= end.Date).ToListAsync();
    }
}
