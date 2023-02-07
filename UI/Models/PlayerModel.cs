using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public partial class PlayerModel : ObservableObject
{
    [ObservableProperty] private List<CardModel> _cards;

    public PlayerModel()
    {
        Cards = new List<CardModel>();
    }
}