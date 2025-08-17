using Domain.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services
{
    public class HoroscopeService : IHoroscopeService
    {
        private readonly HttpClient _httpClient;

        public HoroscopeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDailyAsync(string zodiacSign)
        {
            var apiUrl = $"https://horoscope-app-api.vercel.app/api/v1/get-horoscope/daily?sign={zodiacSign.ToLower()}&day=today";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var parsed = JsonSerializer.Deserialize<HoroscopeResponse>(
                    jsonResponse,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                return parsed?.Data?.Content ?? "Geen horoscoop beschikbaar.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Horoscope API error: {ex.Message}");
                return "Er is een fout opgetreden bij het ophalen van de horoscoop.";
            }
        }
    }

    // API RESPONSE MODELS
    public class HoroscopeResponse
    {
        [JsonPropertyName("data")]
        public HoroscopeData? Data { get; set; }
    }

    public class HoroscopeData
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("horoscope_data")]
        public string? Content { get; set; }
    }
}
