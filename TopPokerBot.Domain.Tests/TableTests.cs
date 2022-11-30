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

		//Act
		var table = new Table(Guid.NewGuid(), number, null, new());

		//Assret

		table.Number.Should()
			.Be(number);

		table.CardDeck.Should()
			.NotBeNull();

		table.CardDeck.Items.Should()
			.NotBeEmpty();

		table.CardDeck.Items.Should()
			.HaveCount(52);

		table.CardDeck.Items.Should()
			.OnlyHaveUniqueItems();
	}
}