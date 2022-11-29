using Reo.Core.BaseDomainModels.ReoBusiness;

namespace TopPokerBot.Domain.Games.Tables.Settings.Rules;

/// <inheritdoc />
public class TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes : IReoBusinessRule
{
	private readonly TimeSpan _timeOut;

	/// <summary>
	/// .ctor
	/// </summary>
	public TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(TimeSpan timeOut)
	{
		_timeOut = timeOut;
	}

	/// <inheritdoc />
	public string Message => "Time out should be more than zero and less than two minutes";

	/// <inheritdoc />
	public string Property => nameof(Settings.TimeOut);

	/// <inheritdoc />
	public bool IsBroken()
	{
		return _timeOut <= TimeSpan.Zero || _timeOut.Minutes >= 2;
	}
}