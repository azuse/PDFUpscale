using System;
using System.IO;
using System.Linq;
using CommandLine;

namespace PDFUpscale;

public static class Program
{
    public static Options Option { get; set; } = new Options( );

    public static void Main(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
    }

    public static void Run(Options option)
    {
        Option = option;
        if (!Options.Models.Contains(Option.Model))
            Option.Model = Options.Models[2];
        if (File.Exists(Option.Input))
        {
            UpscalePDF.Upscale(Option.Input, Option.Output);
        }
        else if (Directory.Exists(Option.Input))
        {
            DirectoryInfo directory = new(Option.Input);
            foreach (FileInfo file in directory.GetFiles("*.pdf", SearchOption.TopDirectoryOnly))
                UpscalePDF.Upscale(file.FullName, $"{Option.Output}/Upscale_{file.Name}");
        }
        else
        {
            throw new FileNotFoundException($"找不到{Option.Input}", Option.Input);
        }
    }

    public static void RunImages(Options option)
    {
        Option = option;
        if (!Options.Models.Contains(Option.Model))
            Option.Model = Options.Models[2];
        DirectoryInfo directory = new(Option.Input);
        foreach (FileInfo file in directory.GetFiles("*.png", SearchOption.TopDirectoryOnly))
            UpscaleImage.Upscale(file.FullName);

    }
}
