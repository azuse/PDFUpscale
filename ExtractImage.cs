using Aspose.Pdf;
using Aspose.Pdf.Devices;

namespace PDFUpscale;

public static class ExtractImage
{
    public static void Extract(string file, string dest)
    {
        Document pdf = new(file);
        for (int i = 1; i <= pdf.Pages.Count; i++)
        {
            Page page = pdf.Pages[i];
            if (page.IsBlank(0.01)) continue;
            PngDevice png = new( );
            png.Process(page, $"{dest}/{i.ToString( ).PadLeft(3, '0')}.png");
        }
        pdf.Dispose( );
    }
}
