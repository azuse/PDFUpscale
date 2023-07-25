using System.Diagnostics;

namespace PDFUpscale;

public static class UpscaleImage
{
    public static void Upscale(string image)
    {
        Process? process = Process.Start(new ProcessStartInfo
        {
            FileName = "realesrgan.exe",
            Arguments = $"-i \"{image}\" -o \"{image}\" -n {Program.Option.Model} -s {Program.Option.Scale} -g {Program.Option.GPU} -f png",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        process?.WaitForExit( );
    }
}
