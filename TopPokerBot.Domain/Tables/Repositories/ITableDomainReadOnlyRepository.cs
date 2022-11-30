using Reo.Core.BaseDomainModels.Interfaces;

namespace TopPokerBot.Domain.Tables.Repositories;

/// <inheritdoc />
public interface ITableDomainReadOnlyRepository : IReoDomainReadOnlyRepository<Table, Guid>
{
}