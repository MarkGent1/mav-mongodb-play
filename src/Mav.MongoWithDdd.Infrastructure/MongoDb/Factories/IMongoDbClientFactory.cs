using MongoDB.Driver;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Factories;

public interface IMongoDbClientFactory
{
    IMongoClient CreateClient();
}
