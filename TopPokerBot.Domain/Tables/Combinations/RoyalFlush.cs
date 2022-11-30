using TopPokerBot.Domain.Tables.Enums;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables.Combinations;

/// <inheritdoc />
public class RoyalFlush : ICombination
{
	private const int Weight = 1000;

	private readonly KindOfRank[] _royalFlushSequence =
	{
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

		var cardsBySuits = sortedCards.GroupBy(x => x.Suit);

		if (cardsBySuits.Select(cardsBySuit => cardsBySuit.Select(x => x.KindOfRank))
			.Any(kindsOfRanks => kindsOfRanks.SequenceEqual(_royalFlushSequence)))
		{
			return new(true, Weight);
		}

		return new(false, null);
	}
}