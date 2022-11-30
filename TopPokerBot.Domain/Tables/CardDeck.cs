using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.Enums;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables;

/// <summary>
/// card deck
/// </summary>
public class CardDeck : IReoDomainModel
{
	private readonly HashSet<Card> _cardDeck;

	/// <summary>
	/// .ctor
	/// </summary>
	public CardDeck()
	{
		var suits = Enum.GetValues(typeof(Suit))
			.Cast<Suit>()
			.ToArray();

		var kindsOfRanks = Enum.GetValues(typeof(KindOfRank))
			.Cast<KindOfRank>()
			.ToArray();

		_cardDeck = (from suit in suits
					from kindOfRank in kindsOfRanks
					select new Card(suit, kindOfRank)).ToHashSet();
	}

	/// <summary>
	/// card deck
	/// </summary>
	public IReadOnlyCollection<Card> Items => _cardDeck;
}