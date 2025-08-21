using Mav.MongoWithDdd.Core.Domain.Sites;

namespace Mav.MongoWithDdd.Application.Queries.Sites;

public record GetSiteByIdQuery(string Id) : IQuery<Site>;
