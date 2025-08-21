﻿using Mav.MongoWithDdd.Core.Interfaces;
using MediatR;

namespace Mav.MongoWithDdd.Infrastructure.Behaviors;

public class DomainEventDispatchingBehavior<TRequest, TResponse>(IAggregateTracker tracker, IMediator mediator) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IAggregateTracker _tracker = tracker;
    private readonly IMediator _mediator = mediator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = await next(cancellationToken);

        var aggregates = _tracker.GetTrackedAggregates();
        foreach (var aggregate in aggregates)
        {
            foreach (var domainEvent in aggregate.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }

            aggregate.ClearDomainEvents();
        }

        _tracker.Clear();
        return response;
    }
}
