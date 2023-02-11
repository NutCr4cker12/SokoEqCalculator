using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.controls;


public partial class CardListView : ContentView
{
    public static readonly BindableProperty CardsProperty =
            BindableProperty.Create(nameof(Cards), typeof(ObservableCollection<CardModel>), typeof(CardListView), propertyChanged: OnCardsPropertyChange);

    private static void OnCardsPropertyChange(BindableObject bindable, object _, object newValue)
    {
        var self = (CardListView)bindable;
        ArgumentNullException.ThrowIfNull(self);
        self.Cards = (ObservableCollection<CardModel>)newValue;
    }

    public ObservableCollection<CardModel> Cards
    {
        get => (ObservableCollection<CardModel>)GetValue(CardsProperty);
        set => SetValue(CardsProperty, value);
    }

    public static readonly BindableProperty OnCardClickedProperty =
            BindableProperty.Create(nameof(OnCardClicked), typeof(IRelayCommand<CardModel>), typeof(DeckView), defaultValue: null);
    public IRelayCommand<CardModel> OnCardClicked
    {
        get => (IRelayCommand<CardModel>)GetValue(OnCardClickedProperty);
        set => SetValue(OnCardClickedProperty, value);
    }

    public CardListView()
    {
        InitializeComponent();
    }
}