using System;
using System.IO;
using PDFUpscale.Properties;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;

namespace PDFUpscale;

public static class UpscalePDF
{
    public static void Upscale(FileInfo file, string dest)
    {
        PdfDocument pdf = new(file.FullName);
        Console.WriteLine($"{Text.Upscale} {file.Name}");

        DirectoryInfo imageDir = new($"{file.Directory?.FullName}/__PDFUpscaleTemp");
        string imageDirPath = imageDir.FullName;
        Directory.CreateDirectory(imageDirPath);
        ExtractImage.Extract(pdf, imageDirPath);
        foreach (FileInfo image in imageDir.GetFiles("*.png"))
        {
            Console.WriteLine($"\t{Text.UpscaleImage} {Path.GetFileNameWithoutExtension(image.FullName)}");
            UpscaleImage.Upscale(image.FullName);
        }

        int count = 0;
        PdfImageHelper helper = new( );
        foreach (PdfPageBase page in pdf.Pages)
        {
            foreach (PdfImageInfo image in helper.GetImagesInfo(page))
            {
                string path = $"{imageDirPath}/{count.ToString( ).PadLeft(3, '0')}.png";
                helper.ReplaceImage(image, PdfImage.FromFile(path));
                count++;
            }
        }
        pdf.SaveToFile(dest, FileFormat.PDF);
    }
}
