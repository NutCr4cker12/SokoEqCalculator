using System.Collections.ObjectModel;

namespace SokoEqCalculator.Models;

public class DeckModel
{
    private readonly List<CardModel> _cards;
    public ObservableCollection<CardModel> Cards => new (_cards);

    public DeckModel()
    {
        _cards = new List<CardModel>(52);
        var suites = new []{ 's', 'h', 'd', 'c' };
        var ranks = new[] { 'A','K','Q','J','T','9','8','7','6','5','4','3','2' };
        for (int rankIdx = 0; rankIdx < ranks.Length; rankIdx++)
        {
            string rank = ranks[rankIdx].ToString();
            for (int suiteIdx = 0; suiteIdx < suites.Length; suiteIdx++)
            {
                var suite = suites[suiteIdx].ToString();
                var card = new CardModel(rankIdx * 4 + suiteIdx, rank, suite);
                _cards.Add(card);
            }
        }
    }

    public void RemoveCard(CardModel cardModel)
    {
        var card = _cards.First(n => n.Hash == cardModel.Hash);
        card.IsAvailable = false;
    }

    public void AddCard(CardModel cardModel)
    {
        var card = _cards.First(n => n.Hash == cardModel.Hash);
        card.IsAvailable = true;
    }
}