using Mav.MongoWithDdd.Core.Attributes;
using Mav.MongoWithDdd.Core.Domain.Customers;
using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Documents;

[CollectionName("customers")]
public class CustomerDocument : IEntity
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Postcode { get; set; } = default!;

    public static CustomerDocument FromDomain(Customer customer) => new()
    {
        Id = customer.Id,
        Name = customer.Name,
        Street = customer.Address.Street,
        City = customer.Address.City,
        Postcode = customer.Address.Postcode
    };

    public Customer ToDomain() =>
        new(Id, Name, new Address(Street, City, Postcode));
}
