using TopPokerBot.Domain.Tables;
using TopPokerBot.Domain.Tables.Repositories;

namespace TopPokerBot.Infrastructure.Tables.DomainRepositories;

public class TableDomainReadOnlyRepository : ITableDomainReadOnlyRepository
{
	private readonly Guid _id = Guid.Parse("9B9A6F92-1DC0-4403-8DBA-7576A80E4CEF");

	private readonly Guid _settingsId = Guid.Parse("7C9A6F92-1DC0-4403-8DBA-7576A80E4CEF");

	public async Task<Table> GetAsync(Guid id, CancellationToken token) =>
		new(_id, 5, new(_settingsId, 6, TimeSpan.FromMinutes(1), new(10, 25)), new());
}