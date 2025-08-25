using Domain.Entities;
using Microsoft.Maui.Controls;

namespace Stap10.Views;

[QueryProperty(nameof(Model), "Model")]
public partial class ReadingPage : ContentPage
{
    public JustForToday? Model
    {
        get => BindingContext as JustForToday;
        set => BindingContext = value;
    }

    public ReadingPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
        => await Shell.Current.GoToAsync("..");
}
