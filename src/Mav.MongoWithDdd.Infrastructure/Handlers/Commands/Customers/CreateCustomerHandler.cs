using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Commands.Customers;
using Mav.MongoWithDdd.Core.Domain.Customers;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Documents;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Commands.Customers;

// Example storing as Customer domain object directly
/*public class CreateCustomerHandler(IGenericRepository<Customer> repo) : ICommandHandler<CreateCustomerCommand, string>
{
    private readonly IGenericRepository<Customer> _repo = repo;

    public async Task<TrackedResult<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(Guid.NewGuid().ToString(), request.Name, request.Address);

        await _repo.AddAsync(customer, cancellationToken);

        return new TrackedResult<string>(customer.Id, customer);
    }
}*/

// Example storing as CustomerDocument
public class CreateCustomerHandler(IGenericRepository<CustomerDocument> repo) : ICommandHandler<CreateCustomerCommand, string>
{
    private readonly IGenericRepository<CustomerDocument> _repo = repo;

    public async Task<TrackedResult<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(Guid.NewGuid().ToString(), request.Name, request.Address);

        var customerDocument = CustomerDocument.FromDomain(customer);

        await _repo.AddAsync(customerDocument, cancellationToken);

        return new TrackedResult<string>(customer.Id, customer);
    }
}
