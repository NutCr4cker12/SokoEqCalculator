using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

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
    public PlayerView()
    {
        InitializeComponent();
    }

    private void OpenCardSelectionClicked(object sender, EventArgs e)
    {
        
    }
}