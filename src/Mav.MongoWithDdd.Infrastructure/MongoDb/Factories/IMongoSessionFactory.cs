using MongoDB.Driver;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Factories;

public interface IMongoSessionFactory
{
    IClientSessionHandle GetSession();
}
