using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PDFUpscale;

public static class UpscaleImage
{
    public static void Batch(IEnumerable<FileInfo> images, Action<FileInfo> action)
    {
        int threads = 0;
        foreach (FileInfo image in images)
        {
            action(image);
            Exec(image.FullName, threads >= Program.Option.Thread);
            threads++;
            threads %= Program.Option.Thread;
        }
    }

    public static void Exec(string image, bool wait)
    {
        Process? process = Process.Start(new ProcessStartInfo
        {
            FileName = "realesrgan.exe",
            Arguments = $"-i \"{image}\" -o \"{image}\" -n {Program.Option.Model} -s {Program.Option.Scale} -g {Program.Option.GPU} -f png",
            UseShellExecute = false,
            CreateNoWindow = true
        });
        if (wait)
            process?.WaitForExit( );
    }
}
