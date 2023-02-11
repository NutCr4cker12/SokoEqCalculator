using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;
using SokoEqCalculator.Services;

namespace SokoEqCalculator.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IAlertService _alertService;
    [ObservableProperty] private PlayerModel _player1;
    [ObservableProperty] private PlayerModel _player2;
    [ObservableProperty] private DeckModel _deck;
    [ObservableProperty] private CardModel _card;
    public MainViewModel(IAlertService alertService)
    {
        _alertService = alertService;
        Deck = new DeckModel();
        Player1 = new PlayerModel();
        Player2 = new PlayerModel();
        Card = new CardModel();
    }

    [RelayCommand]
    private void OnPlayerCardClicked(CardModel model)
    {
        //if (model.IsAvailable)
        //{
        //    Deck.RemoveCard(model);
        //}
        //else
        //{
        //    Deck.AddCard(model);
        //}
    }

    [RelayCommand]
    private async void OnCalculateEquity()
    {
        if (Player1.Cards.Count == 0 || Player2.Cards.Count == 0)
        {
            await _alertService.ShowAlert("OOPS", "Players doesn't have cards, please check your input");
            return;
        }

        if (Player1.Cards.Count != Player2.Cards.Count)
        {
            await _alertService.ShowAlert("OOPS", "Players card count must match, please check your input");
            return;
        }

        await _alertService.ShowAlert("Sorry", "Not implemented yet but hang in there!");
    }
}
