using Newtonsoft.Json;
using System.Diagnostics;
using System.Windows.Input;
using WeatherDemo.Models;
using WeatherDemo.ViewModels;

namespace WeatherDemo.Pages;

public partial class WeatherInfo : ContentPage
{

     private readonly WeatherInfoViewModel _viewModel;
	public WeatherInfo(WeatherInfoViewModel viewModel )
	{
		InitializeComponent();
        _viewModel = viewModel;

        // disabled navigation bar 
       // NavigationPage.SetHasNavigationBar(this, false);

        //	BindingContext = new WeatherInfoViewModel();
        BindingContext = _viewModel;
       


	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
      //  NavigationPage.SetHasNavigationBar(this, false);
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeatherDetail(_viewModel));
    }
}