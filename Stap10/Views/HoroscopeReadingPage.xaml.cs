using Domain.Entities;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace Stap10.Views;

[QueryProperty(nameof(Model), "Model")]
public partial class HoroscopeReadingPage : ContentPage
{
    public Horoscope? Model
    {
        get => BindingContext as Horoscope;
        set => BindingContext = value;
    }

    public ICommand BackCommand { get; }

    public HoroscopeReadingPage()
    {
        InitializeComponent();
        BackCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (Model is not null && string.IsNullOrWhiteSpace(Model.FullText))
            await Model.LoadAsync();
    }

    private async void OnBackTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

}
