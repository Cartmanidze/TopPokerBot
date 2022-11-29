using Reo.Core.BaseDomainModels.Extensions;
using TopPokerBot.Domain.Tables.Enums;
using TopPokerBot.Domain.Tables.Rules;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables.Events;

/// <summary>
/// event for table create
/// </summary>
public class TableCreateEvent
{
	private TableCreateEvent(Guid id, int number, Settings settings, IReadOnlyCollection<Card> cardDeck)
	{
		Id = id;
		Number = number;
		Settings = settings;
		CardDeck = cardDeck;
	}

	/// <summary>
	/// Identifier
	/// </summary>
	public Guid Id { get; }

	/// <summary>
	/// Number of table
	/// </summary>
	public int Number { get; }

	/// <summary>
	/// settings
	/// </summary>
	public Settings Settings { get; }

	/// <summary>
	/// Набор карт
	/// </summary>
	public IReadOnlyCollection<Card> CardDeck { get; }

	/// <summary>
	/// Create
	/// </summary>
	public static TableCreateEvent Create(int number, int numberOfPlayers, TimeSpan timeOut, RateSetting rateSetting)
	{
		new NumberOfPlayersShouldBeSixOrNine(numberOfPlayers).CheckRule();

		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(timeOut).CheckRule();

		var settings = new Settings(Guid.NewGuid(), numberOfPlayers, timeOut, rateSetting);

		var cardDeck = InitializeCardDeck();

		return new(Guid.NewGuid(), number, settings, cardDeck);
	}

	private static IReadOnlyCollection<Card> InitializeCardDeck()
	{
		var suits = Enum.GetValues(typeof(Suit))
			.Cast<Suit>()
			.ToArray();

		var kindsOfRanks = Enum.GetValues(typeof(KindOfRank))
			.Cast<KindOfRank>()
			.ToArray();

		var cardDeck = (from suit in suits
						from kindOfRank in kindsOfRanks
						select new Card(suit, kindOfRank)).ToList();

		return cardDeck;
	}
}