#pragma warning disable CS8618
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

    [Option('i', "input", Required = true, HelpText = "输入 PDF 文件(夹)")]
    public string Input { get; set; }

    [Option('o', "output", Required = true, HelpText = "输出 PDF 文件(夹)")]
    public string Output { get; set; }

    [Option('m', "model", Default = "realesrgan-x4plus-anime", Required = false, HelpText = "使用的模型")]
    public string Model { get; set; } = "realesrgan-x4plus-anime";

    [Option('s', "scale", Default = 4, Required = false, HelpText = "放大倍数")]
    public int Scale { get; set; } = 4;

    [Option('g', "gpu", Default = "auto", Required = false, HelpText = "所用 GPU 序号")]
    public string GPU { get; set; } = "auto";

    [Option('t', "thread", Default = 1, Required = false, HelpText = "图片处理并发数")]
    public int Thread { get; set; } = 1;

    [Option("merge-only", Default = false, Required = false, HelpText = "是否仅合并图像")]
    public bool MergeOnly { get; set; } = false;
}
