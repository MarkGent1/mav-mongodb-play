using MediatR;

namespace Mav.MongoWithDdd.Application;

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TrackedResult<TResult>> where TCommand : ICommand<TrackedResult<TResult>>
{
}
