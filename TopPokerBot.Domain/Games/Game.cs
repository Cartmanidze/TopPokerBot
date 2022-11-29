using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Games.Tables;

namespace TopPokerBot.Domain.Games;

/// <summary>
/// Texas hold'em game
/// </summary>
public class Game : IReoAggregateRoot
{
	/// <summary>
	/// .ctr
	/// </summary>
	/// <param name="table">Table</param>
	public Game(Table table)
	{
		Table = table;
	}

	/// <summary>
	/// Table
	/// </summary>
	public Table Table { get; }
}