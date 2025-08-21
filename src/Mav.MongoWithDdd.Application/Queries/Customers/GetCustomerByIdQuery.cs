using Mav.MongoWithDdd.Core.Domain.Customers;

namespace Mav.MongoWithDdd.Application.Queries.Customers;

public record GetCustomerByIdQuery(string Id) : IQuery<Customer>;
