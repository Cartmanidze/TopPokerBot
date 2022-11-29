using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables;

/// <summary>
/// settings of game
/// </summary>
public class Settings : IReoDomainModel
{
	/// <summary>
	/// .ctor
	/// </summary>
	public Settings(Guid id, int numberOfPlayers, TimeSpan timeOut,
					RateSetting rateSetting)
	{
		Id = id;
		NumberOfPlayers = numberOfPlayers;
		TimeOut = timeOut;
		RateSetting = rateSetting;
	}

	/// <summary>
	/// Identifier
	/// </summary>
	public Guid Id { get; }

	/// <summary>
	/// Max number of players
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
}