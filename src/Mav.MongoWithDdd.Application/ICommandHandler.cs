using MediatR;

namespace Mav.MongoWithDdd.Application;

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
}
