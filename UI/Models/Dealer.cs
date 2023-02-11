namespace SokoEqCalculator.Models;

public static class Dealer
{
    public static void HandleCardClick(CardModel card, DeckModel deck, PlayerModel player)
    {
        // The card is assigned to another player
        if (!card.IsAvailable && !player.Id.Equals(card.BelongsToPlayer))
        {
            return;
        }
        
        if (card.IsAvailable)
        {
            HandleCardAdd(card, deck, player);
            return;
        }

        HandleCardRemove(card, deck, player);
    }

    private static void HandleCardAdd(CardModel card, DeckModel deck, PlayerModel player)
    {
        // Player already has 5 cards - can't assign more
        if (player.Cards.Count == 5)
        {
            return;
        }

        deck.RemoveCard(card);
        card.AssignToPlayer(player);
        player.AddCard(card);
    }

    private static void HandleCardRemove(CardModel card, DeckModel deck, PlayerModel player)
    {
        player.RemoveCard(card);
        card.RemoveFromPlayer(player);
        deck.AddCard(card);
    }

    /// <summary>
    /// Sets the CardProperties of whom the Card is belonging to
    /// </summary>
    /// <param name="deck"></param>
    /// <param name="player"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void SetViewPerspective(DeckModel deck, PlayerModel player)
    {
        var usedCards = deck.Cards.Where(n => !n.IsAvailable);
        foreach (var card in usedCards)
        {
            card.UpdateCardBelonging(player);
        }
    }
}