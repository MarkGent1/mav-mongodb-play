using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Queries.Sites;
using Mav.MongoWithDdd.Core.Domain.Sites;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Queries.Sites;

public class GetSiteByIdQueryHandler(IGenericRepository<Site> repository) : IQueryHandler<GetSiteByIdQuery, Site>
{
    private readonly IGenericRepository<Site> _repository = repository;

    public async Task<Site> Handle(GetSiteByIdQuery request, CancellationToken cancellationToken)
    {
        var site = await _repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Site with ID {request.Id} not found.");

        return site;
    }
}
