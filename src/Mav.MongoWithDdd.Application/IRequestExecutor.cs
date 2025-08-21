namespace Mav.MongoWithDdd.Application;

public interface IRequestExecutor
{
    Task<TResponse> ExecuteCommand<TResponse>(ICommand<TrackedResult<TResponse>> command, CancellationToken cancellationToken = default);
    Task<TrackedResult<TResponse>> ExecuteTrackedCommand<TResponse>(ICommand<TrackedResult<TResponse>> command, CancellationToken cancellationToken = default);
    Task<TResponse> ExecuteQuery<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}
