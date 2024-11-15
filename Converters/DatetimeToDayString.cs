using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Converters
{
    public class DatetimeToDayString : IValueConverter
    {
        private static readonly string[] PersianDayNames = {
            "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"
        };
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    PersianCalendar persianCalendar = new PersianCalendar();
                    int dayOfWeek = (int)persianCalendar.GetDayOfWeek(dateTime);

                    string dayName = PersianDayNames[dayOfWeek];

                    return dayName;
                }
            }

            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
