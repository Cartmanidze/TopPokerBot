namespace TopPokerBot.Domain.Games.Settings;

/// <summary>
/// settings of game
/// </summary>
public class Setting
{
	/// <summary>
	/// Number of playes
	/// </summary>
	public int NumberOfPlayers { get; set; }

	/// <summary>
	/// Time out
	/// </summary>
	public TimeSpan TimeOut { get; set; }
}