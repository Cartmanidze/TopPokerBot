using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.Events;

namespace TopPokerBot.Domain.Tables;

/// <summary>
/// Model describing the table
/// </summary>
public class Table : IReoAggregateRoot
{
	private readonly HashSet<Card> _cardDeck;

	/// <summary>
	/// .ctor
	/// </summary>
	private Table(Guid id, int number, Settings settings, IEnumerable<Card> cardDeck)
	{
		Id = id;

		Number = number;

		Settings = settings;

		_cardDeck = cardDeck.ToHashSet();
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
	/// Settings
	/// </summary>
	public Settings Settings { get; private set; }

	/// <summary>
	/// Card deck
	/// </summary>
	public IReadOnlyCollection<Card> CardDeck => _cardDeck;

	/// <summary>
	/// Apply
	/// </summary>
	public static Table Apply(TableCreateEvent tableCreateEvent) => new(tableCreateEvent.Id, tableCreateEvent.Number,
		tableCreateEvent.Settings, tableCreateEvent.CardDeck);

	/// <summary>
	/// Apply
	/// </summary>
	public Table Apply(SettingsEditEvent settingsEditEvent)
	{
		Settings = new(Settings.Id, Settings.NumberOfPlayers, settingsEditEvent.TimeOut, settingsEditEvent.RateSetting);

		return this;
	}
}