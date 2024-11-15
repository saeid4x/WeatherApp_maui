using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherDemo.Models;
using WeatherDemo.Pages;
using WeatherDemo.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherDemo.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherInfoViewModel
    {
        public string PlaceName { get; set; }
        public string SearchButtonText { get; set; } = "جستجو";
        public string ErrorMessage { get; set; }
        public bool IsLoadingVisible { get; set; } = false;
        public WeatherData weatherData { get; set; }
        HttpClient client;
        public WeatherDaily2 todayWeather { get; set; }

        public readonly INavigationService _navigationService;
        public WeatherInfoViewModel(INavigationService navigationService)
        {
          client= new HttpClient();
            _navigationService = navigationService;

            Debug.WriteLine($"--- placename = {PlaceName} ");
            //SearchButtonText = "جستجو";
           IsLoadingVisible = false;

            //SearchCommand.Execute("Tehran");


        }

      

       

        public ICommand SearchCommand =>
       new Command(async (address) =>
       {
           IsLoadingVisible = true;
           PlaceName = address.ToString();
           SearchButtonText = "لطفا صبر کنید ...";
           ErrorMessage = "در حال دریافت اطلاعات ...";


           //get coordinate async 
           var location = await GetCoordinateAsync(address.ToString());
           Debug.WriteLine($"--- lat = {location.Latitude} | lng = {location.Longitude}");

           // get weather data 
               await GetWeatherData(location);
           //ErrorMessage = "  information weather fetched .....";
           Debug.WriteLine($"*** {weatherData.current.weather_code}");

           if (location.Latitude != 0 || location.Longitude !=0)
           {

               // go to main page
               await _navigationService.NavigationToAsync<WeatherInfo>();
              
               ErrorMessage = "";
               IsLoadingVisible = false;
               SearchButtonText = "جستجو";
               ErrorMessage = "";
           }
           else
           {
               ErrorMessage = "city not exist";

           }

      



       });

        private async Task GetWeatherData(Location location)
        {
                var response = await client.GetAsync(Utilities.Constants.OpenMeteoUrl(location));

            if(response.IsSuccessStatusCode)
            {
                using(var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                    weatherData = data;

                    // today weather 
                    todayWeather = new WeatherDaily2
                    {
                        time = weatherData.daily.time[0],
                        temperature_2m_min = weatherData.daily.temperature_2m_min[0],
                        temperature_2m_max = weatherData.daily.temperature_2m_max[0],
                        weather_code = weatherData.daily.weather_code[0],
                        sunset = weatherData.daily.sunset[0],
                        sunrise = weatherData.daily.sunrise[0],
                        uv_index_max = weatherData.daily.uv_index_max[0],
                    };

                    // get weather daily 
                    for (int i=0; i < weatherData.daily.time.Length; i++)
                    {
                        var dailyItem = new WeatherDaily2
                        {
                            time = weatherData.daily.time[i],
                            temperature_2m_min = weatherData.daily.temperature_2m_min[i],
                            temperature_2m_max = weatherData.daily.temperature_2m_max[i],
                            weather_code = weatherData.daily.weather_code[i],
                            sunset = weatherData.daily.sunset[i],
                            sunrise = weatherData.daily.sunrise[i],
                            uv_index_max = weatherData.daily.uv_index_max[i],
                        };

                        weatherData.dailyWeatherItems.Add(dailyItem);
                    }

                    Debug.WriteLine($"--- daily Weather Items = {weatherData.dailyWeatherItems.Count}");
                

                    // get hourly weather data
                    string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

                    for(int i=0; i<weatherData.hourly.time.Length; i++)
                    {


                        if (weatherData.hourly.time[i].StartsWith(todayDate))
                        {
                            Debug.WriteLine($"--- YES {weatherData.hourly.is_day[i]}");
                            var hourlyWeatherItem = new HourlyWeather2
                            {
                                time = weatherData.hourly.time[i],
                                is_day = weatherData.hourly.is_day[i],
                                temperature_2m = weatherData.hourly.temperature_2m[i],
                                weather_code = weatherData.hourly.weather_code[i],
                                uv_index = weatherData.hourly.uv_index[i],
                            };

                            if (hourlyWeatherItem != null)
                            {
                                Debug.WriteLine($"---  today hourrly Weather time = {hourlyWeatherItem.time}");
                                weatherData.hourlyWeatherItems.Add(hourlyWeatherItem);
                                Debug.WriteLine($"---  hourrly Weather Items = {weatherData.hourly.time.Length}");
                            }
                        }
                    }


                 
                }
            }
 
        }

        private async Task<Location> GetCoordinateAsync(string address)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(Utilities.Constants.ApiUrl(address));

                var responseJson = JsonConvert.DeserializeObject<OpenCageData>(response);

                var firstResponse = responseJson?.results?.FirstOrDefault();

                if (firstResponse != null)
                {
                    var lat = firstResponse.geometry.lat;
                    var lng = firstResponse.geometry.lng;

                    var location = new Location(lat, lng);

                    return location;
                }

                return null;


            }
        }

    }
}
