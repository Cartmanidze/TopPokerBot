using Reo.Core.BaseDomainModels.Extensions;
using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.Events;
using TopPokerBot.Domain.Tables.Rules;

namespace TopPokerBot.Domain.Tables;

/// <summary>
/// Model describing the table
/// </summary>
public class Table : IReoAggregateRoot
{
	/// <summary>
	/// .ctor
	/// </summary>
	public Table(Guid id, int number, Settings settings, CardDeck cardDeck)
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
	/// Settings
	/// </summary>
	public Settings Settings { get; private set; }

	/// <summary>
	/// Card deck
	/// </summary>
	public CardDeck CardDeck { get; }

	/// <summary>
	/// Apply
	/// </summary>
	public static Table Apply(TableCreateEvent tableCreateEvent)
	{
		new NumberOfPlayersShouldBeSixOrNine(tableCreateEvent.NumberOfPlayers).CheckRule();

		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(tableCreateEvent.TimeOut).CheckRule();

		return new(Guid.NewGuid(), tableCreateEvent.Number,
			new(Guid.NewGuid(), tableCreateEvent.NumberOfPlayers, tableCreateEvent.TimeOut, tableCreateEvent.RateSetting), new());
	}

	/// <summary>
	/// Apply
	/// </summary>
	public Table Apply(SettingsEditEvent settingsEditEvent)
	{
		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(settingsEditEvent.TimeOut).CheckRule();

		Settings = new(Settings.Id, Settings.NumberOfPlayers, settingsEditEvent.TimeOut, settingsEditEvent.RateSetting);

		return this;
	}
}