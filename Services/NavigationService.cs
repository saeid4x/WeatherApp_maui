using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDemo.Services
{
    public class NavigationService : INavigationService
    {
        public IServiceProvider _serviceProvider;
        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task NavigationToAsync<T>() where T : Page
        {
            var page = _serviceProvider.GetService<T>();
            if(page != null)
            {
                NavigationPage.SetHasNavigationBar(page, false);
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                throw new InvalidOperationException($"Page of type {typeof(T)} not found.");
            }
        }
    }
}
