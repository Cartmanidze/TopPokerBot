using TopPokerBot.Domain.Tables;
using TopPokerBot.Domain.Tables.Repositories;

namespace TopPokerBot.Infrastructure.Tables.DomainRepositories;

public class TableDomainWriteOnlyRepository : ITableDomainWriteOnlyRepository
{
	public Task<Guid> SaveAsync(Table domain, CancellationToken token) => throw new NotImplementedException();
}