using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SokoEqCalculator.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private PlayerModel _player1;
    [ObservableProperty] private PlayerModel _player2;
    [ObservableProperty] private DeckModel _deck;
    [ObservableProperty] private CardModel _card;
    public MainViewModel()
    {
        Deck = new DeckModel();
        Player1 = new PlayerModel();
        Player2 = new PlayerModel();
        Card = new CardModel();
    }

    [RelayCommand]
    private void OnDeckCardClicked(CardModel model)
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
            var snackbar = Snackbar.Make(message: "Players doesn't have cards");
            await snackbar.Show();
            return;
        }

        if (Player1.Cards.Count != Player2.Cards.Count)
        {
            var snackbar = Snackbar.Make(message: "Players card count must match");
            await snackbar.Show();
            return;
        }
    }

    private async void ShowError(string text)
    {
        var snackbar = Snackbar.Make(message: text);
    }
}
