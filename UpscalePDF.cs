using System;
using System.IO;
using Aspose.Pdf;

namespace PDFUpscale;

public static class UpscalePDF
{
    public static void Upscale(string file, string dest)
    {
        FileInfo pdf = new(file);
        Console.WriteLine("Upscale " + pdf.Name);

        DirectoryInfo imageDir = new($"{pdf.Directory?.FullName}/__PDFUpscaleTemp");
        string imageDirPath = imageDir.FullName;
        Directory.CreateDirectory(imageDirPath);
        ExtractImage.Extract(pdf.Name, imageDirPath);
        foreach (FileInfo image in imageDir.GetFiles("*.png"))
        {
            Console.WriteLine($"\tUpscale image {Path.GetFileNameWithoutExtension(image.FullName)}");
            UpscaleImage.Upscale(image.FullName, $"{imageDirPath}/Upscale_{image.Name}");
        }

        Document result = new(file);
        int count = 0;
        for (int i = 1; i <= result.Pages.Count; i++)
        {
            for (int j = 1; j <= result.Pages[i].Resources.Images.Count; j++)
            {
                FileStream image = new($"{imageDirPath}/{count.ToString( ).PadLeft(3, '0')}.png", FileMode.Open);
                result.Pages[i].Resources.Images.Replace(j, image);
                image.Close( );
                count++;
            }
        }
        result.Save(dest, SaveFormat.Pdf);
    }
}
