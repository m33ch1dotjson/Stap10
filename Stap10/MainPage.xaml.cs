using Domain.Entities;
using System.Collections.ObjectModel;

namespace Stap10
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Horoscope> Horoscopes {  get; set; }
        public ObservableCollection<Horoscope> Horoscopes2 { get; set; }

        public MainPage()
        {
            InitializeComponent();
            InitializeHoroscopes();
            BindingContext = this; 
        }

        private void InitializeHoroscopes()
        {
            Horoscopes = new ObservableCollection<Horoscope>
                {
                    new Horoscope { ZodiacSign = "Ram", Image = "aries.png"},
                    new Horoscope { ZodiacSign = "Stier", Image = "taurus.png"},
                    new Horoscope { ZodiacSign = "Tweelingen", Image = "gemini.png"},
                    new Horoscope { ZodiacSign = "Kreeft", Image = "cancer.png"},
                    new Horoscope { ZodiacSign = "Leeuw", Image = "leo.png"},
                    new Horoscope { ZodiacSign = "Maagd", Image = "virgo.png"},
                    new Horoscope { ZodiacSign = "Weegschaal", Image = "libra.png"},
                    new Horoscope { ZodiacSign = "Schorpioen", Image = "scorpio.png"},
                    new Horoscope { ZodiacSign = "Boogschutter", Image = "sagittarius.png"},
                    new Horoscope { ZodiacSign = "Steenbok", Image = "capricorn.png"},
                    new Horoscope { ZodiacSign = "Waterman", Image = "aquarius.png"},
                    new Horoscope { ZodiacSign = "Vissen", Image = "pisces.png"}
                };
            Horoscopes2 = new ObservableCollection<Horoscope>
                {

                } ;
        }
    }
}
