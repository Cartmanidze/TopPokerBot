using System.Text.Json.Serialization;
using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.ValueObjects;

namespace TopPokerBot.Domain.Tables.Events;

/// <summary>
/// event for edit settings
/// </summary>
public class SettingsEditDomainEvent : IReoDomainEvent
{
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