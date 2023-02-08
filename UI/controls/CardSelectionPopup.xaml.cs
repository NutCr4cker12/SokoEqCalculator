using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.controls;

public partial class CardSelectionPopup : Popup
{
    public static readonly BindableProperty DeckProperty =
            BindableProperty.Create(nameof(Deck), typeof(DeckModel), typeof(CardSelectionPopup));
    public DeckModel Deck
    {
        get => (DeckModel)GetValue(DeckProperty);
        set => SetValue(DeckProperty, value);
    }

    public static readonly BindableProperty OnCardClickedProperty =
            BindableProperty.Create(nameof(OnCardClicked), typeof(IRelayCommand<CardModel>), typeof(CardSelectionPopup));
    public IRelayCommand<CardModel> OnCardClicked
    {
        get => (IRelayCommand<CardModel>)GetValue(OnCardClickedProperty);
        set => SetValue(OnCardClickedProperty, value);
    }

    public CardSelectionPopup(DeckModel deck, IRelayCommand<CardModel> onCardClicked)
    {
        Deck = deck;
        OnCardClicked = onCardClicked;
        InitializeComponent();
    }
    public CardSelectionPopup()
    {
        InitializeComponent();
    }
}