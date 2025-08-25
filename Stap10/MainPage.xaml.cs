using Domain.Entities;
using Domain.Interfaces;
using System.Collections.ObjectModel;
using Stap10.Views;

namespace Stap10
{
    public partial class MainPage : ContentPage
    {
        private readonly IHoroscopeService _service;

        public ObservableCollection<Horoscope> Horoscopes { get; } = new();
        public ObservableCollection<Horoscope> Horoscopes2 { get; } = new();

        public MainPage(IHoroscopeService service)
        {
            InitializeComponent();
            _service = service;
            BindingContext = this;

            _ = InitializeHoroscopesAsync();
        }

        private async Task InitializeHoroscopesAsync()
        {
            var items = new[]
            {
                new Horoscope(_service, "aries", "aries.png", "Ram"),
                new Horoscope(_service, "taurus", "taurus.png", "Stier"),
                new Horoscope(_service, "gemini", "gemini.png", "Tweelingen"),
                new Horoscope(_service, "cancer", "cancer.png", "Kreeft"),
                new Horoscope(_service, "leo", "leo.png", "Leeuw"),
                new Horoscope(_service, "virgo", "virgo.png", "Maagd"),
                new Horoscope(_service, "libra", "libra.png", "Weegschaal"),
                new Horoscope(_service, "scorpio", "scorpio.png", "Schorpioen"),
                new Horoscope(_service, "sagittarius", "sagittarius.png", "Boogschutter"),
                new Horoscope(_service, "capricorn", "capricorn.png", "Steenbok"),
                new Horoscope(_service, "aquarius", "aquarius.png", "Waterman"),
                new Horoscope(_service, "pisces", "pisces.png", "Vissen")
            };

            foreach (var h in items)
                Horoscopes.Add(h);

            foreach (var h in Horoscopes)
                await h.LoadAsync();
        }

        private async void OnCardTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is Horoscope model)
            {
                Console.WriteLine($"Tapped: {model.ZodiacSign}");
                await Shell.Current.GoToAsync(nameof(HoroscopeReadingPage),
                    new Dictionary<string, object> { { "Model", model } });
            }
            else
            {
                Console.WriteLine("⚠️ e.Parameter was null!");
            }
        }
    }
}

