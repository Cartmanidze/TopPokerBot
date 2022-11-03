using TopPokerBot.Domain.Enums;

namespace TopPokerBot.Domain;

/// <summary>
/// Record describing the card model
/// </summary>
/// <param name="Suit"> The suit of the card </param>
/// <param name="KindOfRank"> The kind of rank of the card </param>
public record Card(Suit Suit, KindOfRank KindOfRank);