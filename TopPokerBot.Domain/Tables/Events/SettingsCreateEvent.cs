using Reo.Core.BaseDomainModels.Extensions;
using TopPokerBot.Domain.Tables.Rules;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables.Events;

/// <summary>
/// event for settings create
/// </summary>
public class SettingsCreateEvent
{
	private SettingsCreateEvent(Guid id, int numberOfPlayers, TimeSpan timeOut, RateSetting rateSetting)
	{
		TimeOut = timeOut;
		RateSetting = rateSetting;
		NumberOfPlayers = numberOfPlayers;
	}

	/// <summary>
	/// Identifier
	/// </summary>
	public Guid Id { get; }

	/// <summary>
	/// number of players
	/// </summary>
	public int NumberOfPlayers { get; }

	/// <summary>
	/// Time out
	/// </summary>
	public TimeSpan TimeOut { get; }

	/// <summary>
	/// setting of rate
	/// </summary>
	public RateSetting RateSetting { get; }

	/// <summary>
	/// Create
	/// </summary>
	public static SettingsCreateEvent Create(int numberOfPlayers, TimeSpan timeOut, RateSetting rateSetting)
	{
		new NumberOfPlayersShouldBeSixOrNine(numberOfPlayers).CheckRule();

		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(timeOut).CheckRule();

		return new(Guid.NewGuid(), numberOfPlayers, timeOut, rateSetting);
	}
}