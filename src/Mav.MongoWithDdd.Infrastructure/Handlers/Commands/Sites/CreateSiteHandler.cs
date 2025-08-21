using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Commands.Sites;
using Mav.MongoWithDdd.Core.Domain.Sites;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Commands.Sites;

public class CreateSiteHandler(IGenericRepository<Site> repo) : ICommandHandler<CreateSiteCommand, string>
{
    private readonly IGenericRepository<Site> _repo = repo;

    public async Task<string> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
    {
        var site = new Site
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Street = request.Street,
            City = request.City,
            Postcode = request.Postcode
        };

        await _repo.AddAsync(site, cancellationToken);

        return site.Id;
    }
}
