using FluentAssertions;
using TopPokerBot.Domain.Tables;
using TopPokerBot.Domain.Tables.Events;
using Xunit;

namespace TopPokerBot.Domain.Tests;

public class TableTests
{
	[Fact]
	public void When_table_create_check_correctness_result()
	{
		//Arrange
		const int number = 1;

		//Act
		var table = Table.Apply(TableCreateEvent.Create(number, 9, TimeSpan.FromSeconds(30), default));

		//Assret

		table.Number.Should()
			.Be(number);

		table.CardDeck.Should()
			.NotBeNull();

		table.CardDeck.Should()
			.NotBeEmpty();

		table.CardDeck.Should()
			.HaveCount(52);

		table.CardDeck.Should()
			.NotBeEmpty();

		table.CardDeck.Should()
			.OnlyHaveUniqueItems();
	}
}