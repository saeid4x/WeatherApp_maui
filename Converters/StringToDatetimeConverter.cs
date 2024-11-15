using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Converters
{
    public class StringToDatetimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
             

            
                var datetime = DateTime.ParseExact(value.ToString(), "yyyy-MM-ddTHH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            Debug.WriteLine($"--- value string = {value.ToString}");
            Debug.WriteLine($"--- converted value = {datetime}");

                return datetime;
             

           
            //if (value is string timeString)
            //{
            //    Debug.WriteLine($"--- Input String: {timeString}");
            //    if (DateTime.TryParse(timeString, out DateTime dateTime))
            //    {
            //        Debug.WriteLine($"--- Parsed DateTime: {dateTime}");
            //        return dateTime;
            //    }
            //    else
            //    {
            //        Debug.WriteLine("--- Parsing failed");
            //    }
            //}
            //return DateTime.MinValue; // or some default value
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
