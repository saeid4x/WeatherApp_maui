using WeatherDemo.ViewModels;

namespace WeatherDemo.Pages;

public partial class WeatherDetail : ContentPage
{
    private readonly WeatherInfoViewModel _viewModel;
	public WeatherDetail(WeatherInfoViewModel viewModel)
	{
		InitializeComponent();

        _viewModel = viewModel;
        //diabled navigation bar
      //  NavigationPage.SetHasNavigationBar(this, false);

        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
       // NavigationPage.SetHasNavigationBar(this, false);
    }

}