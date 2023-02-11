using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public partial class CardModel : ObservableObject
{
    public int Hash;
    [ObservableProperty] private string _rank;
    [ObservableProperty] private string _suite;
    [ObservableProperty] private bool _isAvailable;
    [ObservableProperty] private bool _isAvailableForThisPlayer;
    public Guid? BelongsToPlayer { get; private set; }

    public CardModel(): this(0, "A", "s"){ }
    public CardModel(int hash, string rank, string suite)
    {
        Hash = hash;
        Rank = rank;
        Suite = suite;
        IsAvailable = true;
        IsAvailableForThisPlayer = true;
    }

    public void AssignToPlayer(PlayerModel player)
    {
        BelongsToPlayer = player.Id;
        IsAvailable = false;
        IsAvailableForThisPlayer = true;
    }

    public void RemoveFromPlayer(PlayerModel player)
    {
        BelongsToPlayer = null;
        IsAvailable = true;
        IsAvailableForThisPlayer = true;
    }

    public void UpdateCardBelonging(PlayerModel player)
    {
        IsAvailableForThisPlayer = player.Id.Equals(BelongsToPlayer);
    }

    public override string ToString() => $"{Rank}{Suite}";
}
