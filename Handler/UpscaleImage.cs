using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PDFUpscale.Handler;

public static class UpscaleImage
{
    public static void Batch(List<FileInfo> images, Action<FileInfo> action)
    {
        for (int i = 0; i < images.Count; i += Program.Option.Thread)
        {
            Parallel.ForEach(
                images.GetRange(i, Math.Min(Program.Option.Thread, images.Count - i)),
                image =>
                {
                    action(image);
                    Exec(image.FullName);
                }
            );
        }
    }

    public static void Exec(string image)
    {
        string executable = "";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            executable = @".\runtime\realesrgan.exe";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            executable = @"./runtime/realesrgan-linux";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            executable = @"./runtime/realesrgan-macos";
        Process? process = Process.Start(new ProcessStartInfo
        {
            FileName = executable,
            Arguments = $"-i \"{image}\" -o \"{image}\" -n {Program.Option.Model} -s {Program.Option.Scale} -g {Program.Option.GPU} -f png",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        process?.WaitForExit( );
    }
}
