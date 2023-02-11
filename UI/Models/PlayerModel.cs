﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.Models;

public partial class PlayerModel : ObservableObject
{
    public readonly Guid Id = new ();
    [ObservableProperty] private List<CardModel> _cards;
    [ObservableProperty] private string _cardsString;
    public PlayerModel()
    {
        Cards = new List<CardModel>();
        CardsString = "";
    }

    public void RemoveCard(CardModel cardModel)
    {
        for (int idx = 0; idx < Cards.Count; idx++)
        {
            if (Cards[idx].Hash == cardModel.Hash)
            {
                CardsString = CardsString.Replace(Cards[idx].ToString(), "");
                Cards.RemoveAt(idx);
                return;
            }
        }
    }

    public void AddCard(CardModel cardModel)
    {
        CardsString = $"{CardsString}{cardModel.ToString()}";
        Cards.Add(cardModel);
    }
}