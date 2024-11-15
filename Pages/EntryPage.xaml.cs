using WeatherDemo.ViewModels;

namespace WeatherDemo.Pages;

public partial class EntryPage : ContentPage
{
	private readonly WeatherInfoViewModel _viewModel;
	public EntryPage(WeatherInfoViewModel viewModel)
	{
		InitializeComponent();

        //diabled navigation bar
      //  NavigationPage.SetHasNavigationBar(this, false);

        _viewModel = viewModel;
		BindingContext = _viewModel;


	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
       // NavigationPage.SetHasNavigationBar(this, false);
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
		  

		// await Navigation.PushAsync(new WeatherInfo());	

    }
}