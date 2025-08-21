using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Uow;

public class AggregateTracker : IAggregateTracker
{
    private readonly HashSet<IAggregateRoot> _tracked = [];

    public void Track(IAggregateRoot aggregate)
    {
        if (aggregate != null)
            _tracked.Add(aggregate);
    }

    public IReadOnlyCollection<IAggregateRoot> GetTrackedAggregates() => [.. _tracked];

    public void Clear() => _tracked.Clear();
}
