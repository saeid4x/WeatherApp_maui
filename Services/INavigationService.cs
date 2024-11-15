using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Services
{
    public interface INavigationService
    {
        Task NavigationToAsync<T>() where T : Page;
    }
}
