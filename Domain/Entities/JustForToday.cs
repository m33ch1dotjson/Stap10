using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class JustForToday
    {
        public string Image = "na.png"; 

        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;   // "MM-dd"

        [JsonPropertyName("quote")]
        public string Quote { get; set; } = string.Empty;

        [JsonIgnore]
        public IJustForTodayService? Service { get; private set; }

        public void AttachService(IJustForTodayService service) => Service = service;

        /// <summary>
        /// Vult deze instance met de quote van vandaag.
        /// </summary>
        public async Task LoadForTodayAsync(CancellationToken ct = default)
            => await LoadForDateAsync(DateTime.Now, ct);

        /// <summary>
        /// Vult deze instance met de quote voor een specifieke datum.
        /// </summary>
        public async Task LoadForDateAsync(DateTime date, CancellationToken ct = default)
        {
            if (Service is null)
                throw new InvalidOperationException(
                    "Service niet gezet. Roep eerst AttachService(IJustForTodayService) aan.");

            await Service.InitializeAsync(ct);
            var found = Service.GetJFTForToday(date);
            if (found is not null)
            {
                Date = found.Date;
                Quote = found.Quote;
            }
            else
            {
                Date = date.ToString("MM-dd");
                Quote = "Geen quote gevonden voor deze datum.";
            }
        }
        public static string ToKey(DateTime d) => d.ToString("MM-dd");
    }
}
