using System;
using System.IO;
using System.Linq;
using PDFUpscale.Properties;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Utilities;

namespace PDFUpscale.Handler;

public static class UpscalePDF
{
    public static void Exec(FileInfo file, string dest)
    {
        PdfDocument pdf = new(file.FullName);
        Console.WriteLine($"{Text.Upscale} {file.Name}");

        DirectoryInfo imageDir = new($"{file.Directory?.FullName}/__{file.Name}.extracted");
        string imageDirPath = imageDir.FullName;
        Directory.CreateDirectory(imageDirPath);

        if (!Program.Option.MergeOnly)
        {
            ExtractImage.Extract(pdf, imageDirPath);
            UpscaleImage.Batch(
                imageDir.GetFiles("*.png").ToList( ),
                (image) => Console.WriteLine($"\t{Text.UpscaleImage} {Path.GetFileNameWithoutExtension(image.FullName)}")
            );
        }

        int count = 1;
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
