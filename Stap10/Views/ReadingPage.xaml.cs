namespace Stap10.Views;

public partial class ReadingPage : ContentPage
{
	public ReadingPage()
	{
		InitializeComponent();
	}

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}