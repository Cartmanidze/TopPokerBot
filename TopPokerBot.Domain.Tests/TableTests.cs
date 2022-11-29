using FluentAssertions;
using TopPokerBot.Domain.Tables;
using Xunit;

namespace TopPokerBot.Domain.Tests;

public class TableTests
{
	[Fact]
	public void When_table_create_check_correctness_result()
	{
		//Arrange
		const int number = 1;

		var id = Guid.NewGuid();

		//Act
		var table = new Table(id, number);

		//Assret
		table.Id.Should()
			.Be(id);

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