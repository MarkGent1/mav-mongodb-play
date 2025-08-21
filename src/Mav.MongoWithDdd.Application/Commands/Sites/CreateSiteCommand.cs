namespace Mav.MongoWithDdd.Application.Commands.Sites;

public record CreateSiteCommand(
    string Name,
    string Street,
    string City,
    string Postcode) : ICommand<string>;
