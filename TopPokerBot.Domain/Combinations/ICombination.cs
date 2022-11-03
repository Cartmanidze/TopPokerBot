namespace TopPokerBot.Domain.Combinations;

/// <summary>
/// Interface describing combination
/// </summary>
public interface ICombination
{
	/// <summary>
	/// Weight of combination
	/// </summary>
	int Weight { get; }

	/// <summary>
	/// Combination is completed
	/// </summary>
	/// <param name="cards"> Hand cards </param>
	/// <returns> Flag completed combination </returns>
	bool Completed(IReadOnlyCollection<Card> cards);
}