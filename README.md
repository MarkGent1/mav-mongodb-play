# MAV MongoDb Playground

## 1. Introduction

### 1.1 Purpose of this repository

The intention for this repository is to act as a personal 'Playground' to demonstrate how to use the MongoDb Client with DDD patterns.

Health checks have been added for:
 - MongoDb

**Note**. Please run the API using the Docker Compose configuration which is set up to run using `localstack` in the container to test AWS connectivity. A MongoDb instance should also be available (in this example it is set up assuming an instance running on the local development machine).

## 2. Key features

### 2.1 Use of MediatR Behaviors

The following `IPipelineBehavior` types are registered:

```
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkTransactionBehavior<,>));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainEventDispatchingBehavior<,>));
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AggregateRootChangedBehavior<,>));
```

Behavior ordering explained

To ensure the correct sequencing, the pipeline follows this logical flow:
- ValidationBehavior – validate the request
- UnitOfWorkTransactionBehavior – start transaction
- Handler Execution – happens between behaviors via await next()
- AggregateRootChangedBehavior – track aggregates from the handler response
- DomainEventDispatchingBehavior – dispatch domain events from tracked aggregates

What to do with the domain events?

```
CustomerCreatedEventHandler(ILogger<CustomerCreatedEventHandler> logger) : INotificationHandler<CustomerCreatedEvent>
```

We can use the `INotificationHandler` handlers to generate `IntegrationEvents` for downstream services to pick up by AWS SNS/SQS for example.

### 2.2 The IAggregateRoot : IEntity

The infrastructure allows for you to use domain models with or without the `IAggregateRoot` designation.

The `Customer` controller and set of handlers is set up to use the `IAggregateRoot` and `ITrackedResult`.

The `Site` controller is a simpler version where no `IAggregateRoot` is used.

### 2.3 Request/response models and mappings

I haven't included mappings and conversions between request, response and entity types here. The purpose of this repo is to highlight the DDD features rather than the basics around mapping types.