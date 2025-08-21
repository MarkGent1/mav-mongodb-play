using Mav.MongoWithDdd.Application;
using Mav.MongoWithDdd.Application.Queries.Customers;
using Mav.MongoWithDdd.Core.Domain.Customers;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Queries.Customers;

public class GetCustomerByIdHandler(IGenericRepository<Customer> repository) : IQueryHandler<GetCustomerByIdQuery, Customer>
{
    private readonly IGenericRepository<Customer> _repository = repository;

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id, cancellationToken) 
            ?? throw new KeyNotFoundException($"Customer with ID {request.Id} not found.");

        return customer;
    }
}
