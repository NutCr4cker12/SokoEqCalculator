using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;
using SokoEqCalculator.Views;

namespace SokoEqCalculator.controls;

public partial class PlayerView : ContentView
{
    public static readonly BindableProperty PlayerProperty =
            BindableProperty.Create(nameof(Player), typeof(PlayerModel), typeof(PlayerView));
    public PlayerModel Player
    {
        get => (PlayerModel)GetValue(PlayerProperty);
        set => SetValue(PlayerProperty, value);
    }

    public static readonly BindableProperty DeckProperty =
            BindableProperty.Create(nameof(Deck), typeof(DeckModel), typeof(PlayerView), propertyChanged: DeckPropertyChanged);

    private static void DeckPropertyChanged(BindableObject bindable, object _, object newvalue)
    {
        ((PlayerView)bindable).Deck = (DeckModel)newvalue;
    }

    public DeckModel Deck
    {
        get => (DeckModel)GetValue(DeckProperty);
        set => SetValue(DeckProperty, value);
    }

    public static readonly BindableProperty TextClearCommandProperty =
            BindableProperty.Create(nameof(TextClearedCommand), typeof(ICommand), typeof(PlayerView));
    public ICommand TextClearedCommand
    {
        get => (ICommand)GetValue(TextClearCommandProperty);
        set => SetValue(TextClearCommandProperty, value);
    }
    public PlayerView()
    {
        InitializeComponent();
        TextClearedCommand = new Command(execute: OnTextClear, canExecute: () => true);
    }

    private void OnTextClear()
    {
        // TODO PlayerText isn't updated anywhere...
        TextField.Text = "";
    }

    private void OpenCardSelectionClicked(object sender, EventArgs e)
    {
        Dealer.SetViewPerspective(Deck, Player);
        Application.Current.MainPage.ShowPopup(new CardSelectionPopup(Player, Deck, new RelayCommand<CardModel>(OnCardClicked)));
    }

    private void OnCardClicked(CardModel card)
    {
        Dealer.HandleCardClick(card, Deck, Player);
    }
}