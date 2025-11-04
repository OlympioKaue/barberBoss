using barberBoss.Application.UseCases.ReportsUseCase.Pdf.Colors;
using barberBoss.Application.UseCases.ReportsUseCase.Pdf.Fonts;
using barberBoss.Domain.Repository;
using barberBoss.Exception.ExceptionBase;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;
using Cell = MigraDoc.DocumentObjectModel.Tables.Cell;
using Font = MigraDoc.DocumentObjectModel.Font;

namespace barberBoss.Application.UseCases.ReportsUseCase.Pdf;

public class ReportsBillingsPDF : IReportsBillingsPDF
{
    private readonly IBillingQuery _billinQuery;
    private const int TABLE_HEIGHT = 25;
    private const string CURRENT_SUYMBOL = "R$";
    public ReportsBillingsPDF(IBillingQuery billinQuery)
    {
        _billinQuery = billinQuery;
        GlobalFontSettings.FontResolver = new FontResolver();
    }
    public async Task<byte[]> ExecuteReportsPDF(DateOnly monthYear, int weekNumber)
    {
        var dateIn = new DateTime(year: monthYear.Year, month: monthYear.Month, day: 1);
        var daysInTheMonth = DateTime.DaysInMonth(year: monthYear.Year, month: monthYear.Month);
        var dateInEnd = new DateTime(year: monthYear.Year, month: monthYear.Month, day: daysInTheMonth,
                                     hour: 23, minute: 59, second: 59);

        ValidateMonthAndYear(monthYear, weekNumber);

        var resultBillings = await _billinQuery.GetBillingsWithDayofWeek(dateIn, dateInEnd, weekNumber);
        if (resultBillings is null || resultBillings.Count is 0)
        {
            throw new NotFoundSystem("Nenhum faturamento encontrado para o período informado.");
        }

        var document = CreatDocument();
        var page = CreatePage(document);
        CreateHeaderWithProfilePhotoAndName(page);

        var resultTotal = resultBillings.Sum(ef => ef.Amount);

        CreateTotalBillingWeek(page, monthYear, weekNumber, resultTotal);

        foreach (var billing in resultBillings)
        {
            var table = CreateBarberBoss(page);

            var row = table.AddRow(); //adicione uma linha
            row.Height = TABLE_HEIGHT;

            //primeira linha (titulos)
            AddTitleService(row.Cells[0], billing.ServiceName);
            AddTitleAmount(row.Cells[3]);

            //segunda linha (data,hora,pagamento)
            row = table.AddRow();
            row.Height = TABLE_HEIGHT;

            row.Cells[0].AddParagraph(billing.CreatedAt.ToString($"Y"));
            SetStyleBaseForBillingInformation(row.Cells[0]);
            row.Cells[0].Format.LeftIndent = 7;

            row.Cells[1].AddParagraph(billing.CreatedAt.ToString("t"));
            SetStyleBaseForBillingInformation(row.Cells[1]);
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[2].AddParagraph(billing.PaymentMethod.ToString());
            SetStyleBaseForBillingInformation(row.Cells[2]);
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

            AddColumnForAmount(row.Cells[3], billing.Amount);

            AddWhiteSpace(table);
        }

        return RenderDocuments(document);
    }

    private static void ValidateMonthAndYear(DateOnly monthYear, int weekNumber)
    {
        if (monthYear.Month < 1 || monthYear.Month > 12)
        {
            throw new NotFoundSystem(
            [
                "O número de mêses é representado por:",
                 "01 = [Janeiro]",
                 "02 = [Fevereiro]",
                 "03 = [Março]",
                 "04 = [Abril]",
                 "05 = [Maio]",
                 "06 = [Junho]",
                 "07 = [Julho]",
                 "08 = [Agosto]",
                 "09 = [Setembro]",
                 "10 = [Outubro]",
                 "11 = [Novembro]",
                 "12 = [Dezembro]",
            ]);
        }

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

        if (monthYear.Year < 2000 || monthYear.Year > DateTime.Now.Year + 1)
        {
            throw new NotFoundSystem("O ano informado é inválido, informe entre [2000... 2025]");
        }

    }
    private static Document CreatDocument()
    {
        var document = new Document();
        document.Info.Title = "Relatório de Faturamento por Semana";
        document.Info.Subject = "Relatório gerado para análise de faturamento semanal";
        document.Info.Author = "BarberBoss System";

        var style = document.Styles["Normal"];
        style!.Font.Name = FontHelper.RELEWAY_REGULAR;
        return document;
    }
    private static Section CreatePage(Document document)
    {
        var section = document.AddSection();
        section.PageSetup = document.DefaultPageSetup.Clone();
        section.PageSetup.PageFormat = PageFormat.A4;
        section.PageSetup.LeftMargin = 40;
        section.PageSetup.RightMargin = 40;
        section.PageSetup.TopMargin = 80;
        section.PageSetup.BottomMargin = 80;

        return section;
    }
    private byte[] RenderDocuments(Document document)
    {
        var renderByte = new PdfDocumentRenderer
        {
            Document = document
        };

        renderByte.RenderDocument();

        using var file = new MemoryStream();
        renderByte.PdfDocument.Save(file);
        return file.ToArray();
    }
    private void CreateTotalBillingWeek(Section page, DateOnly monthYear, int weekNumber, decimal total)
    {
        var dateIn = new DateTime(year: monthYear.Year, month: monthYear.Month, day: 1);
        var daysInTheMonth = DateTime.DaysInMonth(year: monthYear.Year, month: monthYear.Month);
        var dateInEnd = new DateTime(
            year: monthYear.Year, month: monthYear.Month, day: daysInTheMonth, hour: 23, minute: 59, second: 59);

        //adicionando o cabeçalho
        var paragraph = page.AddParagraph();
        paragraph.Format.SpaceBefore = "40";
        paragraph.Format.SpaceAfter = "40";
        var weekStart = dateIn.AddDays((weekNumber - 1) * 7);
        var weekEnd = weekStart.AddDays(6);
        var title = $"Faturamento da semana - ({weekStart:dd/MM} e {weekEnd:dd/MM})";
        paragraph.AddFormattedText(title, new Font { Name = FontHelper.ROBOTO_MEDIUM, Size = 15 });

        paragraph.AddLineBreak(); //espaçamento entre linhas

        paragraph.AddFormattedText($"{total:0.00} {CURRENT_SUYMBOL}", new Font { Name = FontHelper.BEBASNEUE_REGULAR, Size = 50 });
    }
    private void CreateHeaderWithProfilePhotoAndName(Section page)
    {
        var table = page.AddTable();
        table.Borders.Visible = false;

        table.AddColumn("2.8cm");
        table.AddColumn("10cm");

        var row = table.AddRow();
        row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;

        var assemblyPhoto = Assembly.GetExecutingAssembly();
        var directoryPhoto = Path.GetDirectoryName(assemblyPhoto.Location);
        var pathFile = Path.Combine(directoryPhoto!, "UseCases", "ReportsUseCase", "Pdf", "Logo",
            "barberBossLogo.png");

        var image = row.Cells[0].AddImage(pathFile);
        image.LockAspectRatio = true;
        image.Width = "2.3cm";
        image.Top = ShapePosition.Center;
        image.Left = ShapePosition.Center;
        image.WrapFormat.DistanceRight = "0.5cm";

        var paragraph = row.Cells[1].AddParagraph("BARBEARIA DO JASON");
        paragraph.Format.Font = new Font { Name = FontHelper.BEBASNEUE_REGULAR, Size = 25 };
        paragraph.Format.Alignment = ParagraphAlignment.Left;
        row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
    }
    private Table CreateBarberBoss(Section page)
    {
        var table = page.AddTable();
        table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Left;
        table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;
        return table;
    }

    private void AddTitleService(Cell cell, string billingTitle)
    {
        cell.AddParagraph(billingTitle);
        cell.Format.Font = new Font { Name = FontHelper.BEBASNEUE_REGULAR, Size = 15, Color = ColorHelp.WHITE };
        cell.Shading.Color = ColorHelp.DARK_GRENN;
        cell.VerticalAlignment = VerticalAlignment.Center;
        cell.MergeRight = 2;
        cell.Format.LeftIndent = 7;
    }

    private void AddTitleAmount(Cell cell)
    {
        cell.AddParagraph("VALOR");
        cell.Format.Font = new Font { Name = FontHelper.BEBASNEUE_REGULAR, Size = 15, Color = ColorHelp.WHITE };
        cell.Shading.Color = ColorHelp.AQUA_GREEN;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void SetStyleBaseForBillingInformation(Cell cell)
    {
        cell.Format.Font = new Font { Name = FontHelper.ROBOTO_REGULAR, Size = 10, Color = ColorHelp.BLACK };
        cell.Shading.Color = ColorHelp.MEDIUM_GRAY;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddColumnForAmount(Cell cell, decimal amount)
    {
        cell.AddParagraph($"{amount} {CURRENT_SUYMBOL}");
        cell.Format.Font = new Font { Name = FontHelper.ROBOTO_REGULAR, Size = 10, Color = ColorHelp.BLACK };
        cell.Shading.Color = ColorHelp.WHITE;
        cell.VerticalAlignment = VerticalAlignment.Center;
    }

    private void AddWhiteSpace(Table table)
    {
        var row = table.AddRow();
        row.Height = 30;
        row.Borders.Visible = false;
    }
}
