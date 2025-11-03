using barberBoss.Application.ScanAssembly;

namespace barberBoss.Application.UseCases.ReportsUseCase.Pdf;

public interface IReportsBillingsPDF : IScanGeneric
{
    Task<byte[]> ExecuteReportsPDF(DateOnly monthYear, int weekNumber);
}
