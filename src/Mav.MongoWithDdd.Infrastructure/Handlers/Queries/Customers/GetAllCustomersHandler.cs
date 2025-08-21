using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Queries.Customers;
using Mav.MongoWithDdd.Core.Attributes;
using Mav.MongoWithDdd.Core.Domain.Customers;
using Mav.MongoWithDdd.Infrastructure.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Queries.Customers;

public class GetAllCustomersHandler(IOptions<MongoConfig> mongoConfig, IMongoClient client) : IQueryHandler<GetAllCustomersQuery, List<Customer>>
{
    private readonly IOptions<MongoConfig> _mongoConfig = mongoConfig;
    private readonly IMongoClient _client = client;

    public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var mongoDatabase = _client.GetDatabase(_mongoConfig.Value.DatabaseName);
        var collectionName = typeof(Customer).GetCustomAttribute<CollectionNameAttribute>()?.Name ?? typeof(Customer).Name;
        var collection = mongoDatabase.GetCollection<Customer>(collectionName);

        var customers = await collection.Find(Builders<Customer>.Filter.Empty).ToListAsync(cancellationToken);
        return customers;
    }
}
