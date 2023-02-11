using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public partial class CardModel : ObservableObject
{
    public int Hash;
    [ObservableProperty] private string _rank;
    [ObservableProperty] private string _suite;
    [ObservableProperty] private bool _isAvailable;
    [ObservableProperty] private bool _isUsedByOtherPlayer;
    public Guid? BelongsToPlayer { get; private set; }

    public CardModel(): this(0, "A", "s"){ }
    public CardModel(int hash, string rank, string suite)
    {
        Hash = hash;
        Rank = rank;
        Suite = suite;
        IsAvailable = true;
        IsUsedByOtherPlayer = false;
    }

    public void AssignToPlayer(PlayerModel player)
    {
        BelongsToPlayer = player.Id;
        IsAvailable = false;
        IsUsedByOtherPlayer = false;
    }

    public void RemoveFromPlayer(PlayerModel player)
    {
        BelongsToPlayer = null;
        IsAvailable = true;
        IsUsedByOtherPlayer = false;
    }

    public override string ToString() => $"{Rank}{Suite}";
}
