using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Utilities
{
    public static class Constants
    {

        public static  string ApiUrl(string address)
        {

          const string api_key = "108bf2627b7442948aa94631da69a43c";
          const string api_url = "https://api.opencagedata.com/geocode/v1";

            return $"{api_url}/json?key={api_key}&q={address}";
        }


        public static string OpenMeteoUrl(Location location)
        {
           return  $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m&hourly=temperature_2m,weather_code,uv_index,is_day&daily=weather_code,temperature_2m_max,temperature_2m_min,sunrise,sunset,uv_index_max&timezone=auto";
        }

    }
}
