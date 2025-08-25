using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Services
{
    public sealed class JustForTodayService : IJustForTodayService
    {
        private List<JustForToday>? _items;

        public async Task InitializeAsync(CancellationToken ct = default)
        {
            try
            {
                var path = ResolveQuotesPath();

                if (!File.Exists(path))
                {
                    Console.WriteLine($"Het bestand 'jft_quotes.json' is niet gevonden op: {path}");
                    _items = new List<JustForToday>();
                    return;
                }

                var json = await File.ReadAllTextAsync(path, Encoding.UTF8, ct);
                _items = JsonSerializer.Deserialize<List<JustForToday>>(json) ?? new List<JustForToday>();
                Console.WriteLine($"Aantal geladen quotes: {_items.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout bij het laden van de quotes: {ex.Message}");
                _items = new List<JustForToday>();
            }
        }

        public JustForToday? GetJFTForToday(DateTime? date = null)
        {
            if (_items == null || _items.Count == 0)
            {
                Console.WriteLine("Geen quotes geladen of lijst is leeg.");
                return null;
            }

            var d = date ?? DateTime.Now;
            var todayKey = d.ToString("MM-dd");
            var jft = _items.FirstOrDefault(x => x.Date == todayKey);
            if (jft == null) Console.WriteLine($"Geen quote gevonden voor datum: {todayKey}");
            return jft;
        }

        // Option A pad-resolutie: eerst AppData, anders ./Data/jft_quotes.json naast binaries
        private static string ResolveQuotesPath()
        {
            var appDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Stap10");
            var appDataPath = Path.Combine(appDataDir, "jft_quotes.json");
            if (File.Exists(appDataPath)) { Console.WriteLine($"JFT in AppData: {appDataPath}"); return appDataPath; }

            var baseDir = AppContext.BaseDirectory ?? Environment.CurrentDirectory;
            var output = Path.Combine(baseDir, "Data", "jft_quotes.json");
            Console.WriteLine($"JFT fallback pad: {output}");
            return output;
        }
    }
}
