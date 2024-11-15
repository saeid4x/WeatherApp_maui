using SkiaSharp.Extended.UI.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Converters
{
    public class WeatherCodeToLottieConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var lottienImageSource = new SKFileLottieImageSource();

            switch(value)
            {
                case 0:
                    lottienImageSource.File = "weather_animations/sunny.json";
                    return lottienImageSource;
                case 1:
                    lottienImageSource.File = "weather_animations/sunny.json";
                    return lottienImageSource;
                case 2:
                    lottienImageSource.File = "weather_animations/partlycloudy-bigsun_3cloud.json";                   
                    return lottienImageSource;
                case 3:
                    lottienImageSource.File = "weather_animations/overcast-no-rain.json";
                    return lottienImageSource;
                case 45:
                    lottienImageSource.File = "weather_animations/fog.json";
                    return lottienImageSource;
                case 48:
                    lottienImageSource.File = "weather_animations/fog.json";
                    return lottienImageSource;
                case 51:
                    lottienImageSource.File = "weather_animations/Drizzle.json";
                    return lottienImageSource;
                case 53:
                    lottienImageSource.File = "weather_animations/Drizzle.json";
                    return lottienImageSource;
                case 55:
                    lottienImageSource.File = "weather_animations/Drizzle.json";
                    return lottienImageSource;
                case 56:
                    lottienImageSource.File = "weather_animations/Drizzle.json";
                    return lottienImageSource;
                case 57:
                    lottienImageSource.File = "weather_animations/Drizzle.json";
                    return lottienImageSource;
                case 61:
                    lottienImageSource.File = "weather_animations/rain-white-cloud.json";
                    return lottienImageSource;
                case 63:
                    lottienImageSource.File = "weather_animations/rain-white-cloud.json";
                    return lottienImageSource;
                case 65:
                    lottienImageSource.File = "weather_animations/rain-white-cloud.json";
                    return lottienImageSource;
                case 66:
                    lottienImageSource.File = "weather_animations/snow.json";
                    return lottienImageSource;
                case 67:
                    lottienImageSource.File = "weather_animations/snow.json";
                    return lottienImageSource;
                case 71:
                    lottienImageSource.File = "weather_animations/snow.json";
                    return lottienImageSource;
                case 73:
                    lottienImageSource.File = "weather_animations/snow.json";
                    return lottienImageSource;
                case 75:
                    lottienImageSource.File = "weather_animations/snow.json";
                    return lottienImageSource;
                case 77:
                    lottienImageSource.File = "weather_animations/snow.json";
                    return lottienImageSource;
                case 80:
                    lottienImageSource.File = "weather_animations/rain-shower.json";
                    return lottienImageSource;
                case 81:
                    lottienImageSource.File = "weather_animations/rain-shower.json";
                    return lottienImageSource;
                case 82:
                    lottienImageSource.File = "weather_animations/rain-shower.json";
                    return lottienImageSource;
                case 85:
                    lottienImageSource.File = "weather_animations/rain-shower.json";
                    return lottienImageSource;
                case 86:
                    lottienImageSource.File = "weather_animations/rain-shower.json";
                    return lottienImageSource;
                case 95:
                    lottienImageSource.File = "weather_animations/angry-cloud-Thunderstorm.json";
                    return lottienImageSource;
                case 96:
                case 99:
                    lottienImageSource.File = "weather_animations/angry-cloud-Thunderstorm.json";
                    return lottienImageSource;
                default: return "weather_animations/weather-loading.json";
            }

          
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
