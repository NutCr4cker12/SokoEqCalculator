using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;
using SokoEqCalculator.Views;

namespace SokoEqCalculator.controls;

public partial class PlayerView : ContentView
{
    public static readonly BindableProperty PlayerProperty =
            BindableProperty.Create(nameof(Player), typeof(PlayerModel), typeof(PlayerView), defaultValue: null);
    public PlayerModel Player
    {
        get => (PlayerModel)GetValue(PlayerProperty);
        set => SetValue(PlayerProperty, value);
    }

    public static readonly BindableProperty DeckProperty =
            BindableProperty.Create(nameof(Deck), typeof(DeckModel), typeof(PlayerView), defaultValue: null);
    public DeckModel Deck
    {
        get => (DeckModel)GetValue(DeckProperty);
        set => SetValue(DeckProperty, value);
    }

    public string PrivateText { get; set; }
    public ICommand TextClearedCommand { get; set; }
    public PlayerView()
    {
        InitializeComponent();
        TextClearedCommand = new Command(execute: OnTextClear, canExecute: () => true);
    }

    private void OnTextClear()
    {
        
    }

    private async void OpenCardSelectionClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new AboutView());
        await Navigation.PushModalAsync(new AboutView());
    }
}