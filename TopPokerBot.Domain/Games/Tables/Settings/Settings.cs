using Reo.Core.BaseDomainModels.Interfaces;

namespace TopPokerBot.Domain.Games.Tables.Settings;

/// <summary>
/// settings of game
/// </summary>
public class Settings : IReoDomainModel
{
	/// <summary>
	/// .ctor
	/// </summary>
	public Settings(Guid id, int numberOfPlayers, TimeSpan timeOut, decimal initialRate, decimal increaseRate)
	{
		Id = id;
		NumberOfPlayers = numberOfPlayers;
		TimeOut = timeOut;
		InitialRate = initialRate;
		IncreaseRate = increaseRate;
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
	/// Initial rate
	/// </summary>
	public decimal InitialRate { get; }

	/// <summary>
	/// Increase rate
	/// </summary>
	public decimal IncreaseRate { get; }

	public static Settings Apply()
}