namespace Mav.MongoWithDdd.Infrastructure.MongoDb;

public record MongoConfig
{
    public string DatabaseUri { get; init; } = default!;
    public string DatabaseName { get; init; } = default!;
    public bool EnableTransactions { get; init; } = true;
}
