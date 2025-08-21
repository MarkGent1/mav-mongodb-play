using Mav.MongoWithDdd.Core.Domain.Customers;
using MediatR;

namespace Mav.MongoWithDdd.Application.Commands.Customers;

public class UpdateCustomerCommand(string id, string name, Address address) : ICommand<TrackedResult<Unit>>
{
    public string Id { get; } = id;
    public string Name { get; } = name;
    public Address Address { get; } = address;
}
