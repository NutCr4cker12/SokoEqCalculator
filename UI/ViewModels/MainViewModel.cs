using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.ViewModels;

internal partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private DeckModel _deck;
    public MainViewModel()
    {
        Deck = new DeckModel();
    }

    [RelayCommand]
    private void OnDeckCardClicked(CardModel model)
    {
        if (model.IsAvailable)
        {
            Deck.RemoveCard(model);
        }
        else
        {
            Deck.AddCard(model);
        }
    }
}
