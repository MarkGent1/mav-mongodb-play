using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Setup;

public class MongoDbHealthCheck : IHealthCheck
{
    private readonly IMongoClient _mongoClient;

    public MongoDbHealthCheck(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _mongoClient.ListDatabaseNamesAsync(cancellationToken);
            return HealthCheckResult.Healthy("MongoDB is reachable.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("MongoDB health check failed.", ex);
        }
    }
}
