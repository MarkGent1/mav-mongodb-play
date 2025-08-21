using Mav.MongoWithDdd.Core.Attributes;
using Mav.MongoWithDdd.Core.Interfaces;

namespace Mav.MongoWithDdd.Core.Domain.Sites;

[CollectionName("sites")]
public class Site : IEntity
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Postcode { get; set; }
}
