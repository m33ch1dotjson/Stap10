using System.IO;
using Microsoft.Maui.Storage;

namespace Stap10.Helpers
{
    public static class JftBootstrap
    {
        public static async Task EnsureSeedAsync()
        {
            var destDir = Path.Combine(FileSystem.AppDataDirectory, "Stap10");
            Directory.CreateDirectory(destDir);

            var dest = Path.Combine(destDir, "jft_quotes.json");
            if (File.Exists(dest)) return;

            // LogicalName in csproj moet "jft_quotes.json" zijn
            using var src = await FileSystem.OpenAppPackageFileAsync("jft_quotes.json");
            using var dst = File.Create(dest);
            await src.CopyToAsync(dst);
        }
    }
}
