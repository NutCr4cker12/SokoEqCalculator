using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public partial class CardModel : ObservableObject
{
    public int Hash;
    [ObservableProperty] private string _rank;
    [ObservableProperty] private string _suite;
    [ObservableProperty] private bool _isAvailable;

    public CardModel(): this(0, "A", "s"){ }
    public CardModel(int hash, string rank, string suite, bool available = true)
    {
        Hash = hash;
        Rank = rank;
        Suite = suite;
        IsAvailable = available;
    }
}
