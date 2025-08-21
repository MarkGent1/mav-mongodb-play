using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Core.Domain.Customers.DomainEvents;

public class CustomerUpdatedEvent(string id) : IDomainEvent
{
    public string Id { get; } = id;
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
