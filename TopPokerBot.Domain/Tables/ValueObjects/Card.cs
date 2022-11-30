using Reo.Core.BaseDomainModels.Interfaces;
using TopPokerBot.Domain.Tables.Enums;

namespace TopPokerBot.Domain.Tables.ValueObjects;

/// <summary>
/// Record describing the card model
/// </summary>
/// <param name="Suit"> The suit of the card </param>
/// <param name="KindOfRank"> The kind of rank of the card </param>
public record Card(Suit Suit, KindOfRank KindOfRank) : IReoValueObject;