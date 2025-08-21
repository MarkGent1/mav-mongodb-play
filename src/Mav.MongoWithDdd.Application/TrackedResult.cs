using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Application;

public class TrackedResult<T>(T result, params IAggregateRoot[] aggregates) : ITrackedResult
{
    public T Result { get; } = result;
    public IReadOnlyCollection<IAggregateRoot> Aggregates { get; } = aggregates;
}
