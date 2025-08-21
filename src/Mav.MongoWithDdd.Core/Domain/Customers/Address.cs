namespace Mav.MongoWithDdd.Core.Domain.Customers;

public class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string Postcode { get; }

    public Address(string street, string city, string postcode)
    {
        Street = street;
        City = city;
        Postcode = postcode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return Postcode;
    }
}
