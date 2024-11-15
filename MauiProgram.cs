using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using WeatherDemo.Pages;
using WeatherDemo.Services;
using WeatherDemo.ViewModels;

namespace WeatherDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    // custom fonts
                    fonts.AddFont("IRANSans(FaNum)_Black.ttf", "iranSans_black");
                    fonts.AddFont("IRANSans(FaNum)_Bold.ttf", "iranSans_bold");
                    fonts.AddFont("IRANSans(FaNum)_Medium.ttf", "iranSans_medium");

                    fonts.AddFont("Manshoor-Black.ttf", "manshoor_black");
                    fonts.AddFont("Manshoor-Bold.ttf", "manshoor_bold");
                    fonts.AddFont("Manshoor-Medium.ttf", "manshoor_medium");

                    fonts.AddFont("Sarbaz_Black.otf", "sarbaz_black");





                });


            builder.Services.AddSingleton<WeatherInfoViewModel>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            builder.Services.AddTransient<EntryPage>();
            builder.Services.AddTransient<WeatherInfo>();
            builder.Services.AddTransient<WeatherDetail>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
