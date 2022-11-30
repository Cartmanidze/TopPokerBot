using FluentAssertions;
using TopPokerBot.Domain.Tables.Combinations;
using TopPokerBot.Domain.Tables.Enums;
using TopPokerBot.Domain.Tables.ValueObjects;
using Xunit;

namespace TopPokerBot.Domain.Tests.Combinations;

public class RoyalFlushTests
{
	[Fact]
	public void When_cards_contains_royal_flush_contains_then_combination_should_be_completed_and_weight_should_be_1000()
	{
		//Arrange
		var cards = new Card[]
		{
			new(Suit.Spades, KindOfRank.Ten),
			new(Suit.Diamonds, KindOfRank.Ace),
			new(Suit.Hearts, KindOfRank.Five),
			new(Suit.Spades, KindOfRank.Jack),
			new(Suit.Spades, KindOfRank.Queen),
			new(Suit.Spades, KindOfRank.King),
			new(Suit.Spades, KindOfRank.Ace)
		};

		var royalFlush = new RoyalFlush();

		//Act
		var result = royalFlush.Completed(cards);

		//Assert
		result.IsCompleted.Should()
			.Be(true);

		result.Weight.Should()
			.Be(1000);
	}
}