using System.IO;

namespace PDFUpscale;

public static class Utils
{
    public static bool IsFile(string file)
    {
        return File.Exists(file);
    }
}
