using System;
using System.IO;
using PDFUpscale.Properties;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;

namespace PDFUpscale;

public static class UpscalePDF
{
    public static void Upscale(string file, string dest)
    {
        FileInfo pdf = new(file);
        Console.WriteLine($"{Text.Upscale} {pdf.Name}");

        DirectoryInfo imageDir = new($"{pdf.Directory?.FullName}/__PDFUpscaleTemp");
        string imageDirPath = imageDir.FullName;
        Directory.CreateDirectory(imageDirPath);
        ExtractImage.Extract(pdf.Name, imageDirPath);
        foreach (FileInfo image in imageDir.GetFiles("*.png"))
        {
            Console.WriteLine($"\t{Text.UpscaleImage} {Path.GetFileNameWithoutExtension(image.FullName)}");
            UpscaleImage.Upscale(image.FullName);
        }

        PdfDocument result = new(file);
        int count = 0;
        PdfImageHelper helper = new( );
        foreach (PdfPageBase page in result.Pages)
        {
            foreach (PdfImageInfo image in helper.GetImagesInfo(page))
            {
                string path = $"{imageDirPath}/{count.ToString( ).PadLeft(3, '0')}.png";
                helper.ReplaceImage(image, PdfImage.FromFile(path));
                count++;
            }
        }
        result.SaveToFile(dest, FileFormat.PDF);
    }
}
