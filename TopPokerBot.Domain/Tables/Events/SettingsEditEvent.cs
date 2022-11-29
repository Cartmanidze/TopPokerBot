using Reo.Core.BaseDomainModels.Extensions;
using TopPokerBot.Domain.Tables.Rules;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables.Events;

/// <summary>
/// event for edit settings
/// </summary>
public class SettingsEditEvent
{
	private SettingsEditEvent(TimeSpan timeOut, RateSetting rateSetting)
	{
		TimeOut = timeOut;
		RateSetting = rateSetting;
	}

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
	public static SettingsEditEvent Create(TimeSpan timeOut, RateSetting rateSetting)
	{
		new TimeOutSettingShouldBeMoreThanZeroAndLessThanTwoMinutes(timeOut).CheckRule();

		return new(timeOut, rateSetting);
	}
}