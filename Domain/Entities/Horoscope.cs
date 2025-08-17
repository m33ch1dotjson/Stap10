using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public sealed class Horoscope
    {
        private readonly IHoroscopeService _service;
        public string ZodiacSign { get; init; }
        public string FullText { get; private set; } = string.Empty;
        public string Image { get; init; }

        public Horoscope(IHoroscopeService service, string zodiacSign, string image)
        {
            _service = service;
            ZodiacSign = zodiacSign;
            Image = image;
        }

        /// <summary>
        /// Haalt de horoscoop op via de service en zet de FullText property.
        /// </summary>
        public async Task LoadAsync()
        {
            FullText = await _service.GetDailyAsync(ZodiacSign);
        }
    }
}
