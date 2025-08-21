using MediatR;

namespace Mav.MongoWithDdd.Core.Interfaces;

public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
}
