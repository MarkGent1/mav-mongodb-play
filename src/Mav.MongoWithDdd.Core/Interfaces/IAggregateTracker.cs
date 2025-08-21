namespace Mav.MongoWithDdd.Core.Interfaces;

public interface IAggregateTracker
{
    void Track(IAggregateRoot aggregate);
    IReadOnlyCollection<IAggregateRoot> GetTrackedAggregates();
    void Clear();
}
