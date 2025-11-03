using barberBoss.Application.UseCases.ReportsUseCase.Excel;
using barberBoss.Application.UseCases.ReportsUseCase.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace barberBoss.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    /// <summary>
    /// Retorna os billings por semana do mês.
    /// </summary>
    /// <param name="weekNumber">
    /// Número da semana do mês (1 a 4 ou 1 a 5, dependendo do mês).
    /// </param>
    /// <param name="dateMonth">
    /// Data de referência para o mês (por exemplo: 2025-10-01).
    /// </param>
    [HttpGet("excel")]
    public async Task<IActionResult> GetExcel(
        [FromQuery] DateOnly monthYear,
        [FromQuery] int weekNumber,
        [FromServices] IReportsBillingsExcel useCase)
    {

        byte[] fileResult = await useCase.ExecuteReportsExcel(monthYear, weekNumber);
        return File(fileResult, MediaTypeNames.Application.Octet, "report.xlsx");
    }

    [HttpGet("pdf")]
    public async Task<IActionResult> GetPDF(
        [FromQuery] DateOnly monthYear, 
        [FromQuery] int weekNumber, 
        [FromServices] IReportsBillingsPDF useCase)
    {
        var file = await useCase.ExecuteReportsPDF(monthYear, weekNumber);
        return File(file, MediaTypeNames.Application.Pdf, "report.pdf");
    }
}
