using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;
using ClosedXML.Excel;

namespace barberBoss.Application.UseCases.ReportsUseCase.Excel;

public class ReportsBillingsExcel : IReportsBillingsExcel
{
    private readonly IBillingQuery _billingQuery;

    public ReportsBillingsExcel(IBillingQuery billingQuery)
    {
        _billingQuery = billingQuery;
    }
    public async Task<byte[]> ExecuteReportsExcel(DateOnly monthYear, int weekNumber)
    {

        var dateIn = new DateTime(year: monthYear.Year, month: monthYear.Month, day: 1);
        var daysInTheMonth = DateTime.DaysInMonth(year: monthYear.Year, month: monthYear.Month);
        var dateInEnd = new DateTime(
            year: monthYear.Year, month: monthYear.Month, day: daysInTheMonth, hour: 23, minute: 59, second: 59);

        ValidateMonthAndYear(monthYear);
        if (weekNumber < 0 || weekNumber > 5)
        {
            throw new NotFoundSystem(
            [
                "O número de semanas é representado por:",
                 "1 = semana [01–07]",
                 "2 = semana [08–14]",
                 "3 = semana [15–21]",
                 "4 = semana [22–28]",
                 "5 = semana [29–30 ou 31]"
            ]);
        }

        var resultOfWeek = await _billingQuery.GetBillingsWithDayofWeek(dateIn, dateInEnd, weekNumber);
        if (resultOfWeek is null || resultOfWeek.Count is 0)
        {
            throw new NotFoundSystem("Nenhum faturamento encontrado para o período informado.");
        }

        using var woorkBook = new XLWorkbook();
        woorkBook.Author = "BarberBoss";
        woorkBook.Style.Font.FontSize = 12;

        var creatWoork = woorkBook.AddWorksheet("Relatório de Faturamento");
        InsertHeader(creatWoork);

        var row = 2;
        foreach (var item in resultOfWeek)
        {
            creatWoork.Cell($"A{row}").Value = item.ServiceName;
            creatWoork.Cell($"B{row}").Value = item.CreatedAt;
            creatWoork.Cell($"C{row}").Value = item.PaymentMethod.ToString();
            creatWoork.Cell($"D{row}").Value = item.ClientName;
            creatWoork.Cell($"E{row}").Value = item.Amount;
            creatWoork.Cell($"E{row}").Style.NumberFormat.Format = "R$ #,##0.00";

            row++;
        }

        var file = new MemoryStream();
        woorkBook.SaveAs(file);
        return file.ToArray();
    }

    private static void InsertHeader(IXLWorksheet xL)
    {
        xL.Cell("A1").Value = "Titulo";
        xL.Cell("B1").Value = "Data de Criação";
        xL.Cell("C1").Value = "Tipo de Pagamento";
        xL.Cell("D1").Value = "Client";
        xL.Cell("E1").Value = "Valor";

        xL.Cells("A1:E1").Style.Font.Bold = true;

        xL.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        xL.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        xL.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        xL.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        xL.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
    }

    private static void ValidateMonthAndYear(DateOnly monthYear)
    {
        if (monthYear.Month < 1 || monthYear.Month > 12)
        {
            throw new NotFoundSystem("O mês informado é inválido.");
        }

        if (monthYear.Year < 2000 || monthYear.Year > DateTime.Now.Year + 1)
        {
            throw new NotFoundSystem("O ano informado é inválido.");
        }

    }
}
