using TopPokerBot.Domain.Enums;

namespace TopPokerBot.Domain.Combinations;

/// <inheritdoc />
public class RoyalFlush : ICombination
{
	private const int Weight = 1000;

	private readonly KindOfRank[] _royalFlushSequence = {
		KindOfRank.Ten,
		KindOfRank.Jack,
		KindOfRank.Queen,
		KindOfRank.King,
		KindOfRank.Ace
	};

	/// <inheritdoc />
	public CombinationResult Completed(IReadOnlyCollection<Card> cards)
	{
		if (cards == null)
		{
			throw new ArgumentNullException(nameof(cards));
		}

		if (cards.Count is < 5 or > 7)
		{
			return new(false, null);
		}

		var sortedCards = cards.OrderBy(x => x.KindOfRank)
			.ToArray();

		var lastFiveCards = sortedCards.TakeLast(5)
			.ToArray();

		var kindsOfRanks = lastFiveCards.Select(x => x.KindOfRank);

		if (kindsOfRanks.SequenceEqual(_royalFlushSequence))
		{
			var cardsBySuits = lastFiveCards.GroupBy(x => x.Suit);

			if (cardsBySuits.Count() == 1)
			{
				return new(true, Weight);
			}
		}

		return new(false, null);
	}
}