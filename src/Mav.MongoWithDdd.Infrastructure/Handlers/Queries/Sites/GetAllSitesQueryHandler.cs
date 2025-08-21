using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Queries.Sites;
using Mav.MongoWithDdd.Core.Attributes;
using Mav.MongoWithDdd.Core.Domain.Sites;
using Mav.MongoWithDdd.Infrastructure.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Queries.Sites;

public class GetAllSitesQueryHandler(IOptions<MongoConfig> mongoConfig, IMongoClient client) : IQueryHandler<GetAllSitesQuery, List<Site>>
{
    private readonly IOptions<MongoConfig> _mongoConfig = mongoConfig;
    private readonly IMongoClient _client = client;

    public async Task<List<Site>> Handle(GetAllSitesQuery request, CancellationToken cancellationToken)
    {
        var mongoDatabase = _client.GetDatabase(_mongoConfig.Value.DatabaseName);
        var collectionName = typeof(Site).GetCustomAttribute<CollectionNameAttribute>()?.Name ?? typeof(Site).Name;
        var collection = mongoDatabase.GetCollection<Site>(collectionName);

        var sites = await collection.Find(Builders<Site>.Filter.Empty).ToListAsync(cancellationToken);
        return sites;
    }
}
