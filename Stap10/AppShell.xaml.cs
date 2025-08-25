using Stap10.Views;

namespace Stap10
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HoroscopeReadingPage), typeof(HoroscopeReadingPage));

            Routing.RegisterRoute(nameof(ReadingPage), typeof(ReadingPage));

            Shell.SetNavBarIsVisible(this, false);
        }
    }
}
