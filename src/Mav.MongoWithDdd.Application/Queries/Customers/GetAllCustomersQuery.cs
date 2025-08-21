using Mav.MongoWithDdd.Core.Domain.Customers;

namespace Mav.MongoWithDdd.Application.Queries.Customers;

public record GetAllCustomersQuery() : IQuery<List<Customer>>;
