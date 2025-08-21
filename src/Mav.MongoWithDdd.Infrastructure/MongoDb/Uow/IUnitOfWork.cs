using MongoDB.Driver;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Uow;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
    IClientSessionHandle Session { get; }
}
