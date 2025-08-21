using Mav.MongoWithDdd.Core.Domain.Sites;

namespace Mav.MongoWithDdd.Application.Queries.Sites;

public record GetAllSitesQuery() : IQuery<List<Site>>;
