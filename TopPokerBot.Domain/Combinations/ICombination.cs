﻿namespace TopPokerBot.Domain.Combinations;

/// <summary>
/// Interface describing combination
/// </summary>
public interface ICombination
{
	/// <summary>
	/// Combination is completed
	/// </summary>
	/// <param name="cards"> Hand cards </param>
	/// <returns> Flag completed combination </returns>
	CombinationResult Completed(IReadOnlyCollection<Card> cards);
}