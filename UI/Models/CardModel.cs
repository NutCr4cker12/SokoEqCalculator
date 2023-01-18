using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public class CardModel : ObservableObject
{
    [field: ObservableProperty] public string Rank { get; set; }
    [field: ObservableProperty] public string Suite { get; set; }
    public CardModel(string rank, string suite)
    {
        Rank = rank;
        Suite = suite;
    }
}
