namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Uow;

public interface ITransactionManager
{
    void BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task AbortTransactionAsync();
}
