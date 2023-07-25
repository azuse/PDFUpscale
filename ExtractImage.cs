using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Spire.Pdf;

namespace PDFUpscale;

public static class ExtractImage
{
    public static void Extract(string file, string dest)
    {
        PdfDocument pdf = new( );
        pdf.LoadFromFile(file);

        List<Image> ListImage = new( );
        for (int i = 0; i < pdf.Pages.Count; i++)
        {
            PdfPageBase page = pdf.Pages[i];
            Image[] images = page.ExtractImages( );
            if (images != null && images.Length > 0)
                ListImage.AddRange(images);
        }
        if (ListImage.Count > 0)
        {
            for (int i = 0; i < ListImage.Count; i++)
            {
                ListImage[i].Save($"{dest}/{i.ToString().PadLeft(3,'0')}.png", ImageFormat.Png);
            }
        }
    }
}
