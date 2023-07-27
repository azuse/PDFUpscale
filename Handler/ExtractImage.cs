using System.Drawing;
using System.Drawing.Imaging;
using Spire.Pdf;

namespace PDFUpscale.Handler;

public static class ExtractImage
{
    public static void Extract(PdfDocument pdf, string dest)
    {
        int count = 1;
        for (int i = 0; i < pdf.Pages.Count; i++)
        {
            Image[] images = pdf.Pages[i].ExtractImages( );
            for (int j = 0; j < images.Length; j++)
            {
                images[j].Save($"{dest}/{count.ToString( ).PadLeft(3, '0')}.png", ImageFormat.Png);
                count++;
            }
        }
        pdf.Dispose( );
    }
}
