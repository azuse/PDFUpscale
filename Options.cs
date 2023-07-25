using CommandLine;

namespace PDFUpscale;

public class Options
{
    public static string[] Models = new string[3]
    {
        "realesr-animevideov3",
        "realesrgan-x4plus",
        "realesrgan-x4plus-anime"
    };

    [Option('i', "input", Required = true, HelpText = "输入 PDF 文件")]
    public string Input { get; set; }

    [Option('o', "output", Required = true, HelpText = "输出 PDF 文件")]
    public string Output { get; set; }

    [Option('m', "model", Default = "realesrgan-x4plus-anime", Required = false, HelpText = "使用的模型")]
    public string? Model { get; set; }

    [Option('s', "scale", Default = 4, Required = false, HelpText = "放大倍数")]
    public int Scale { get; set; }
}
