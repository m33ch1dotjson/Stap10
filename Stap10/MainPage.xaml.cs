using Domain.Entities;
using Domain.Interfaces;
using System.Collections.ObjectModel;
using Stap10.Views;
using Stap10.Helpers;

namespace Stap10
{
    public partial class MainPage : ContentPage
    {
        private readonly IHoroscopeService _service;
        private readonly IJustForTodayService _jftService;

        public ObservableCollection<Horoscope> Horoscopes { get; } = new();
        public ObservableCollection<JustForToday> JustForTodayItems { get; } = new();

        public MainPage(IHoroscopeService service, IJustForTodayService jftService)
        {
            InitializeComponent();
            _service = service;
            _jftService = jftService;

            BindingContext = this;

            _ = InitializeHoroscopesAsync();
            _ = LoadJftAsync();
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

        private async Task LoadJftAsync()
        {
            await JftBootstrap.EnsureSeedAsync();   
            await _jftService.InitializeAsync();   

            var jft = _jftService.GetJFTForToday()
                     ?? new JustForToday { Quote = "Geen quote gevonden voor vandaag." };

            JustForTodayItems.Clear();
            JustForTodayItems.Add(jft);
        }

        private async void OnCardTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter is Horoscope model)
            {
                await Shell.Current.GoToAsync(nameof(HoroscopeReadingPage),
                    new Dictionary<string, object> { { "Model", model } });
            }
            else
            {
                Console.WriteLine("⚠️ e.Parameter was null!");
            }
        }

        private async void OnCardTappedQuote(object sender, TappedEventArgs e)
        {
            if (e.Parameter is JustForToday model)
            {
                await Shell.Current.GoToAsync(nameof(ReadingPage),
                    new Dictionary<string, object> { { "Model", model } });
            }
            else
            {
                Console.WriteLine("⚠️ e.Parameter was null!");
            }
        }
    }
}

