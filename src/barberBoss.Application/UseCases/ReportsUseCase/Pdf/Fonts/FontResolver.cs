using PdfSharp.Fonts;
using System.Reflection;

namespace barberBoss.Application.UseCases.ReportsUseCase.Pdf.Fonts;

public class FontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        var queryFonts = ReadFontFile(faceName);
        if(queryFonts is null)
        {
            queryFonts = ReadFontFile(FontHelper.DEFAULT_FONT);
        }

        var lengthFont =(int) queryFonts!.Length;
        var arrayFont = new byte[lengthFont];

        queryFonts.Read(arrayFont, 0, lengthFont);
        return arrayFont;
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        return new FontResolverInfo(familyName);
    }

    private Stream? ReadFontFile(string resourceName)
    {
       var assembly = Assembly.GetExecutingAssembly();
       return assembly.GetManifestResourceStream($"barberBoss.Application.UseCases.ReportsUseCase.Pdf.Fonts.{resourceName}.ttf");
    }
}
