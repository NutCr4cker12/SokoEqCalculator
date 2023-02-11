using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;
using SokoEqCalculator.Services;

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

    private static void DeckPropertyChanged(BindableObject bindable, object _, object newvalue) => ((PlayerView)bindable).Deck = (DeckModel)newvalue;

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
    private bool _popupOpen { get; set; }
    public PlayerView()
    {
        InitializeComponent();
        TextClearedCommand = new Command(execute: OnTextClear, canExecute: () => true);
        OpenCardsSelectionButton.Clicked += async (s, e) => await OpenCardSelection();

        var tabGesture = new TapGestureRecognizer();
        tabGesture.Tapped += async (s, e) => await OpenCardSelection();
        TextField.GestureRecognizers.Add(tabGesture);

        TextField.Focused += async (s, e) =>
        {
            if (_popupOpen)
            {
                return;
            }
            // Set focus to the Frame because otherwise closing the popup would 
            // leave the focus on the TextField and re-trigger the opening
            Grid.Focus();
            await OpenCardSelection();
        };
    }

    private void OnTextClear() => Dealer.RemoveCardsFromPlayer(Player, Deck);

    private void OnCardClicked(CardModel card) => Dealer.HandleCardClick(card, Deck, Player);

    private async Task OpenCardSelection()
    {
        Dealer.SetViewPerspective(Deck, Player);
        _popupOpen = true;
        var popup = new CardSelectionPopup(Player, Deck, new RelayCommand<CardModel>(OnCardClicked));
        popup.Closed += (s, e) =>
        {
            _popupOpen = false;
        };
        var popupService = Handler?.MauiContext?.Services.GetRequiredService<IPopupService>();
        ArgumentNullException.ThrowIfNull(popupService);
        await popupService.ShowPopup(popup);
    }

}