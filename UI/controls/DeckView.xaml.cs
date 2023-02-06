using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.controls;

public partial class DeckViewNew : ContentView
{
    public static readonly BindableProperty DeckProperty =
            BindableProperty.Create(nameof(Deck), typeof(DeckModel), typeof(DeckViewNew), defaultValue: null, propertyChanged: OnDeckChange);

    private static void OnDeckChange(BindableObject bindable, object oldValue, object newValue)
    {
        var self = (DeckViewNew)bindable;
        ArgumentNullException.ThrowIfNull(self);
        self.Deck = (DeckModel)newValue;
    }
    public DeckModel Deck
    {
        get => (DeckModel)GetValue(DeckProperty);
        set => SetValue(DeckProperty, value);
    }

    public static readonly BindableProperty OnCardClickedProperty =
            BindableProperty.Create(nameof(OnCardClicked), typeof(RelayCommand<CardModel>), typeof(DeckViewNew), defaultValue: null);
    public RelayCommand<CardModel> OnCardClicked
    {
        get => (RelayCommand<CardModel>)GetValue(OnCardClickedProperty);
        set => SetValue(OnCardClickedProperty, value);
    }

    public DeckViewNew()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (OnCardClicked is null || sender is not CardView cardView || cardView.CardModel is null)
        {
            return;
        }
        OnCardClicked!.Execute(cardView.CardModel);
    }
}