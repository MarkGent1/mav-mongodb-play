using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Commands.Sites;
using Mav.MongoWithDdd.Core.Domain.Sites;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;
using MediatR;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Commands.Sites;

public class UpdateSiteHandler(IGenericRepository<Site> repo) : ICommandHandler<UpdateSiteCommand, Unit>
{
    private readonly IGenericRepository<Site> _repo = repo;

    public async Task<Unit> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
    {
        var site = await _repo.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new Exception($"Site {request.Id} not found");

        site.Name = request.Name;
        site.Street = request.Street;
        site.City = request.City;
        site.Postcode = request.Postcode;

        await _repo.UpdateAsync(site, cancellationToken);

        return Unit.Value;
    }
}
