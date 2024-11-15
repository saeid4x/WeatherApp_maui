using System.Runtime.CompilerServices;
using WeatherDemo.Pages;
using WeatherDemo.ViewModels;

namespace WeatherDemo
{
    public partial class App : Application
    {
        private readonly WeatherInfoViewModel _viewModel;
        public App(WeatherInfoViewModel viewModel)
        {
            
            InitializeComponent();
            _viewModel = viewModel;

             MainPage = new NavigationPage(new  EntryPage(_viewModel) );

            //var navPage = new NavigationPage(new EntryPage(_viewModel))
            //{
            //    BarBackgroundColor = Colors.Transparent,
            //    BarTextColor = Colors.Transparent
            //};
            // Disable the navigation bar globally
            //NavigationPage.SetHasNavigationBar(navPage, false);

            //MainPage = navPage;
        }
    }
}
