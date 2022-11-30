using TopPokerBot.Domain.Tables;
using TopPokerBot.Domain.Tables.Events;
using TopPokerBot.Domain.Tables.Repositories;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/tables/{id}", async (Guid id, ITableDomainReadOnlyRepository domainReadOnlyRepository, CancellationToken token) =>
{
	var table = await domainReadOnlyRepository.GetAsync(id, token);

	return table;
});

app.MapPost("/tables", async (TableCreateDomainEvent tableCreateEvent, ITableDomainWriteOnlyRepository domainWriteOnlyRepository, CancellationToken token) =>
{
	var table = Table.Apply(tableCreateEvent);

	await domainWriteOnlyRepository.SaveAsync(table, token);
});

app.MapPut("/tables/{id}/settings", async (Guid id, SettingsEditDomainEvent settingsEditEvent,
											ITableDomainReadOnlyRepository domainReadOnlyRepository,
											ITableDomainWriteOnlyRepository domainWriteOnlyRepository,
											CancellationToken token) =>
{
	var table = await domainReadOnlyRepository.GetAsync(id, token);

	table.Apply(settingsEditEvent);

	await domainWriteOnlyRepository.SaveAsync(table, token);
});

app.Run();