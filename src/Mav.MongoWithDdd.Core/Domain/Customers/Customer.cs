using Mav.MongoWithDdd.Core.Attributes;
using Mav.MongoWithDdd.Core.Domain.Customers.DomainEvents;
using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Core.Domain.Customers;

[CollectionName("customers")]
public class Customer : IAggregateRoot
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }


    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    public Customer(string id, string name, Address address)
    {
        Id = id;
        Name = name;
        Address = address;
        _domainEvents.Add(new CustomerCreatedEvent(Id));
    }

    public void Update(string name, Address address)
    {
        Name = name;
        Address = address;
        _domainEvents.Add(new CustomerUpdatedEvent(Id));
    }

    public void ClearDomainEvents() => _domainEvents.Clear();
}
