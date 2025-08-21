using Mav.MongoWithDdd.Core.Domain.Customers.DomainEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mav.MongoWithDdd.Infrastructure.Handlers.Events.Customers;

public class CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger) : INotificationHandler<CustomerCreatedEvent>
{
    private readonly ILogger<CustomerCreatedEventHandler> _logger = logger;

    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Customer created with ID: {Id}", notification.Id);
        
        return Task.CompletedTask;
    }
}
