using Reo.Core.BaseDomainModels.ReoBusiness;

namespace TopPokerBot.Domain.Games.Tables.Settings.Rules;

/// <inheritdoc />
public class NumberOfPlayersShouldBeSixOrNine : IReoBusinessRule
{
	/// <inheritdoc />
	public string Message { get; }

	/// <inheritdoc />
	public string Property { get; }

	/// <inheritdoc />
	public bool IsBroken() => throw new NotImplementedException();
}