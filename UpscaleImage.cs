using System.Diagnostics;

namespace PDFUpscale;

public static class UpscaleImage
{
    public static void Upscale(string image, string dest)
    {
        Process? process = Process.Start(new ProcessStartInfo
        {
            FileName = "realesrgan.exe",
            Arguments = $"-i \"{image}\" -o \"{dest}\" -n {Program.Option?.Model} -s {Program.Option?.Scale} -f png",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        process?.WaitForExit( );
    }
}
