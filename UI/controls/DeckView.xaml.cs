using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.controls;

public partial class DeckView : ContentView
{
    public static readonly BindableProperty DeckProperty =
            BindableProperty.Create(nameof(Deck), typeof(DeckModel), typeof(DeckView), defaultValue: null, propertyChanged: OnDeckChange);

    private static void OnDeckChange(BindableObject bindable, object oldValue, object newValue)
    {
        var self = (DeckView)bindable;
        ArgumentNullException.ThrowIfNull(self);
        self.Deck = (DeckModel)newValue;
    }
    public DeckModel Deck
    {
        get => (DeckModel)GetValue(DeckProperty);
        set => SetValue(DeckProperty, value);
    }

    public static readonly BindableProperty OnCardClickedProperty =
            BindableProperty.Create(nameof(OnCardClicked), typeof(IRelayCommand<CardModel>), typeof(DeckView), defaultValue: null);
    public IRelayCommand<CardModel> OnCardClicked
    {
        get => (IRelayCommand<CardModel>)GetValue(OnCardClickedProperty);
        set => SetValue(OnCardClickedProperty, value);
    }

    public DeckView()
    {
        InitializeComponent();
    }
}