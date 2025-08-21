using MediatR;

namespace Mav.MongoWithDdd.Application.Commands.Sites;

public class UpdateSiteCommand(
    string id,
    string name,
    string street,
    string city,
    string postcode) : ICommand<Unit>
{
    public string Id { get; } = id;
    public string Name { get; } = name;
    public string Street { get; } = street;
    public string City { get; } = city;
    public string Postcode { get; } = postcode;
}
