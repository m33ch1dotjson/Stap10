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
                new Horoscope(_service, "aries", "aries.png"),
                new Horoscope(_service, "taurus", "taurus.png"),
                new Horoscope(_service, "gemini", "gemini.png"),
                new Horoscope(_service, "cancer", "cancer.png"),
                new Horoscope(_service, "leo", "leo.png"),
                new Horoscope(_service, "virgo", "virgo.png"),
                new Horoscope(_service, "libra", "libra.png"),
                new Horoscope(_service, "scorpio", "scorpio.png"),
                new Horoscope(_service, "sagittarius", "sagittarius.png"),
                new Horoscope(_service, "capricorn", "capricorn.png"),
                new Horoscope(_service, "aquarius", "aquarius.png"),
                new Horoscope(_service, "pisces", "pisces.png")
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

