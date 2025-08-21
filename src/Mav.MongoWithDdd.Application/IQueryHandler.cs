using MediatR;

namespace Mav.MongoWithDdd.Application;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
}
