using Reo.Core.BaseDomainModels.Extensions;
using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.Events;
using TopPokerBot.Domain.Tables.Rules;

namespace TopPokerBot.Domain.Tables;

/// <summary>
/// Model describing the table
/// </summary>
public class Table : IReoAggregateRoot<Guid>
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
	/// Identifier
	/// </summary>
	public Guid Id { get; }

	/// <summary>
	/// Apply
	/// </summary>
	public static Table Apply(TableCreateDomainEvent tableCreateDomainEvent)
	{
		new NumberOfPlayersShouldBeSixOrNine(tableCreateDomainEvent.NumberOfPlayers).CheckRule();

		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(tableCreateDomainEvent.TimeOut).CheckRule();

		return new(Guid.NewGuid(), tableCreateDomainEvent.Number,
			new(Guid.NewGuid(), tableCreateDomainEvent.NumberOfPlayers, tableCreateDomainEvent.TimeOut, tableCreateDomainEvent.RateSetting),
			new());
	}

	/// <summary>
	/// Apply
	/// </summary>
	public Table Apply(SettingsEditDomainEvent settingsEditDomainEvent)
	{
		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(settingsEditDomainEvent.TimeOut).CheckRule(false);

		Settings = new(Settings.Id, Settings.NumberOfPlayers, settingsEditDomainEvent.TimeOut, settingsEditDomainEvent.RateSetting);

		return this;
	}
}