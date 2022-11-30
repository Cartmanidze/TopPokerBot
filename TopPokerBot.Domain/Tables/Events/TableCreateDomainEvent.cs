using System.Text.Json.Serialization;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables.Events;

/// <summary>
/// event for table create
/// </summary>
public class TableCreateDomainEvent
{
	/// <summary>
	/// Number of table
	/// </summary>
	[JsonInclude]
	public int Number { get; private set; }

	/// <summary>
	/// Max number of players
	/// </summary>
	[JsonInclude]
	public int NumberOfPlayers { get; private set; }

	/// <summary>
	/// Time out
	/// </summary>
	[JsonInclude]
	public TimeSpan TimeOut { get; private set; }

	/// <summary>
	/// setting of rate
	/// </summary>
	[JsonInclude]
	public RateSetting RateSetting { get; private set; }
}