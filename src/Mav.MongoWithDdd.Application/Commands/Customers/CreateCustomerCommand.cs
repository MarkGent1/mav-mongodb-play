using Mav.MongoWithDdd.Core.Domain.Customers;

namespace Mav.MongoWithDdd.Application.Commands.Customers;

public record CreateCustomerCommand(string Name, Address Address) : ICommand<TrackedResult<string>>;
