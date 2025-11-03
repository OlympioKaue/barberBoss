using barberBoss.Application.ScanAssembly;
using barberBoss.Communication.Response.Billings;

namespace barberBoss.Application.UseCases.ReportsUseCase.Excel;

public interface IReportsBillingsExcel : IScanGeneric
{
    Task<byte[]> ExecuteReportsExcel(DateOnly monthYear, int weekNumber);
}
