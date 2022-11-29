using Reo.Core.BaseDomainModels.Interfaces;

namespace TopPokerBot.Domain.Tables.ValueObjects;

/// <summary>
/// Settings of rate
/// </summary>
public record RateSetting(decimal Initial, decimal Increase) : IReoValueObject;