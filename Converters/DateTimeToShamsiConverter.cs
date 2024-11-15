using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Converters
{
    public class DateTimeToShamsiConverter : IValueConverter
    {
        private static readonly string[] PersianMonthNames = {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
        };

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            if (value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
                {
                    PersianCalendar persianCalendar = new PersianCalendar();
                    int year = persianCalendar.GetYear(dateTime);
                    int month = persianCalendar.GetMonth(dateTime);
                    int day = persianCalendar.GetDayOfMonth(dateTime);

                    string monthName = PersianMonthNames[month - 1];

                    return $"{day} , {monthName}";
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
