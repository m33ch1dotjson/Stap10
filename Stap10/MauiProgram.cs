using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Services;

namespace Stap10
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Epilogue-Medium.ttf", "Epilogue");
                    fonts.AddFont("fontello.ttf", "Icons");
                    fonts.AddFont("FontAwesomeSolid.otf", "AwesomeSolid");
                });

            builder.Services.AddHttpClient<IHoroscopeService, HoroscopeService>();
            builder.Services.AddSingleton<IJustForTodayService, JustForTodayService>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
