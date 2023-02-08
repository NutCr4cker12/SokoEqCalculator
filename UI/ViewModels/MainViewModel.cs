using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private PlayerModel _player;
    [ObservableProperty] private DeckModel _deck;
    public MainViewModel()
    {
        Deck = new DeckModel();
        Player = new PlayerModel();
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
