using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PDFUpscale.Handler;

public static class UpscaleImage
{
    public static void Batch(List<FileInfo> images, Action<FileInfo> action)
    {
        for (int i = 0; i < images.Count; i += Program.Option.Thread)
        {
            Parallel.ForEach(images.GetRange(i, i + Program.Option.Thread), image =>
            {
                action(image);
                Exec(image.FullName);
            });
        }
    }

    public static void Exec(string image)
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
