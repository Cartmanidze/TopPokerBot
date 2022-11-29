using Reo.Core.BaseDomainModels.ReoBusiness;

namespace TopPokerBot.Domain.Tables.Rules;

/// <inheritdoc />
public class NumberOfPlayersShouldBeSixOrNine : IReoBusinessRule
{
	private readonly decimal _numberOfPlayers;

	/// <summary>
	/// .ctor
	/// </summary>
	public NumberOfPlayersShouldBeSixOrNine(decimal numberOfPlayers) => _numberOfPlayers = numberOfPlayers;

	/// <inheritdoc />
	public string Message => "number of players should be six or nine";

	/// <inheritdoc />
	public string Property => nameof(Settings.NumberOfPlayers);

	/// <inheritdoc />
	public bool IsBroken() => _numberOfPlayers != 6 && _numberOfPlayers != 9;
}