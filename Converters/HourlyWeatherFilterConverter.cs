using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDemo.Models;

namespace WeatherDemo.Converters
{
    public class HourlyWeatherFilterConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<HourlyWeather2> hourlyWeatherItems)
            {
                DateTime currentDateTime = DateTime.Now;

                var filteredItems = hourlyWeatherItems
                    .Where(item => DateTime.TryParse(item.time, out DateTime itemDateTime) && itemDateTime >= currentDateTime)
                    .ToList();

                return new ObservableCollection<HourlyWeather2>(filteredItems);
            }

            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
