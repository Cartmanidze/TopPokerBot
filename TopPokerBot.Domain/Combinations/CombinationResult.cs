namespace TopPokerBot.Domain.Combinations;

/// <summary>
/// Result of combination
/// </summary>
/// <param name="IsCompleted"> Flag is completed </param>
/// <param name="Weight"> Weight of combination </param>
public record CombinationResult(bool IsCompleted, int? Weight);