using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Commands.Customers;
using Mav.MongoWithDdd.Core.Domain.Customers;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;
using MediatR;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Commands.Customers;

public class UpdateCustomerHandler(IGenericRepository<Customer> repo) : ITrackedCommandHandler<UpdateCustomerCommand, Unit>
{
    private readonly IGenericRepository<Customer> _repo = repo;

    public async Task<TrackedResult<Unit>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repo.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new Exception($"Customer {request.Id} not found");

        customer.Update(request.Name, request.Address);

        await _repo.UpdateAsync(customer, cancellationToken);

        return new TrackedResult<Unit>(Unit.Value, customer);
    }
}
