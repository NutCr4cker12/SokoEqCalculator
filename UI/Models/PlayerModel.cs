using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public partial class PlayerModel : ObservableObject
{
    [ObservableProperty] private List<CardModel> _cards;

    public PlayerModel()
    {
        Cards = new List<CardModel>();
    }

    public void RemoveCard(CardModel cardModel)
    {
        for (int idx = 0; idx < Cards.Count; idx++)
        {
            if (Cards[idx].Hash == cardModel.Hash)
            {
                Cards.RemoveAt(idx);
                return;
            }
        }
    }

    public void AddCard(CardModel cardModel)
    {
        Cards.Add(cardModel);
    }
}