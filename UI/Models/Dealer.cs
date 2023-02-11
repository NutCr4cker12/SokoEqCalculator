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

        // TODO Add logic for Card being selected to another player
        if (card.IsAvailable)
        {
            deck.RemoveCard(card);
            card.AssignToPlayer(player);
            player.AddCard(card);
        }
        else
        {
            player.RemoveCard(card);
            card.RemoveFromPlayer(player);
            deck.AddCard(card);
        }
    }
}