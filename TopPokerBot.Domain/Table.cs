namespace TopPokerBot.Domain;

/// <summary>
/// Model describing the table
/// </summary>
public class Table : IAggregateRoot
{
	private readonly HashSet<Card> _cardDeck = new();

	/// <summary>
	/// .ctr
	/// </summary>
	public Table(Guid id, int number)
	{
		Id = id;

		Number = number;

		var suits = Enum.GetValues(typeof(Suit))
			.Cast<Suit>()
			.ToArray();

		var kindsOfRanks = Enum.GetValues(typeof(KindOfRank))
			.Cast<KindOfRank>()
			.ToArray();

		foreach (var suit in suits)
		{
			foreach (var kindOfRank in kindsOfRanks)
			{
				_cardDeck.Add(new(suit, kindOfRank));
			}
		}
	}

	/// <summary>
	/// Identifier
	/// </summary>
	public Guid Id { get; }

	/// <summary>
	/// Number of table
	/// </summary>
	public int Number { get; }

	/// <summary>
	/// Card deck
	/// </summary>
	public IReadOnlyCollection<Card> CardDeck => _cardDeck;
}