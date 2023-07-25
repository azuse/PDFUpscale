using System;
using System.IO;

namespace PDFUpscale;

public static class UpscalePDF
{
    public static void Upscale(string file, string dest)
    {
        FileInfo pdf = new(file);
        Console.WriteLine("Upscale " + pdf.Name);
        DirectoryInfo imageDirectory = new($"{pdf.Directory?.FullName}/__PDFUpscaleTemp");
        Directory.CreateDirectory(imageDirectory.FullName);
        ExtractImage.Extract(pdf.Name, imageDirectory.FullName);
        foreach (FileInfo image in imageDirectory.GetFiles("*.png"))
        {
            Console.WriteLine($"\tUpscale image {Path.GetFileNameWithoutExtension(image.FullName)}");
            UpscaleImage.Upscale(image.FullName, $"{imageDirectory.FullName}/Upscale_{image.Name}");
        }
    }
}
