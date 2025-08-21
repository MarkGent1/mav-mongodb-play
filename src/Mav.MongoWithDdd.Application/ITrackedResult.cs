using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Application;

public interface ITrackedResult
{
    IReadOnlyCollection<IAggregateRoot> Aggregates { get; }
}
