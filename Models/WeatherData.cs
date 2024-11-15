using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Models
{
    public class WeatherData
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string timezone { get; set; }
        public CurrentWeather current { get; set; }
        public HourlyWeather hourly { get; set; }
        public WeatherDaily daily { get; set; }

        public ObservableCollection<HourlyWeather2> hourlyWeatherItems { get; set; } = new ObservableCollection<HourlyWeather2>();
        public ObservableCollection<WeatherDaily2> dailyWeatherItems { get; set; } = new ObservableCollection<WeatherDaily2>();
    }

    public class CurrentWeather
    {
        public string  time { get; set; }
        public float temperature_2m { get; set; }
        public float relative_humidity_2m { get; set; }
        public int weather_code { get; set; }
        public float wind_speed_10m { get; set; }
    }

    public class HourlyWeather
    {
        public string[] time { get; set; }
        public float[] temperature_2m { get; set; }
        public int[] weather_code { get; set; }
        public float[] uv_index { get; set; }
        public int[] is_day { get; set; }
    }

    public class HourlyWeather2
    {
        public string time { get; set; }
        public float temperature_2m { get; set; }
        public int weather_code { get; set; }
        public float uv_index { get; set; }
        public int is_day { get; set; }
    }

    public class WeatherDaily
    {
        public string[]  time { get; set; }
        public int[] weather_code { get; set; }
        public float[] temperature_2m_max { get; set; }
        public float[] temperature_2m_min { get; set; }
        public string[] sunrise { get; set; }
        public string[] sunset { get; set; }
        public float[] uv_index_max { get; set; }
    } 
    
    public class WeatherDaily2
    {
        public string  time { get; set; }
        public int weather_code { get; set; }
        public float temperature_2m_max { get; set; }
        public float temperature_2m_min { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public float uv_index_max { get; set; }
    }
}
