using Mav.MongoWithDdd.Core.Interfaces;
using Mav.MongoWithDdd.Infrastructure.Behaviors;
using Mav.MongoWithDdd.Infrastructure.Handlers.Commands.Customers;
using Mav.MongoWithDdd.Infrastructure.MongoDb;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Factories;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Repositories;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Uow;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Mav.MongoWithDdd.Infrastructure.Setup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(GuidRepresentation.Standard));
        
        services.Configure<MongoConfig>(configuration.GetSection("Mongo"));
        services.AddSingleton<IMongoDbClientFactory, MongoDbClientFactory>();
        services.AddScoped<IMongoSessionFactory, MongoSessionFactory>();
        services.AddScoped(sp => sp.GetRequiredService<IMongoSessionFactory>().GetSession());
        services.AddSingleton(sp => sp.GetRequiredService<IMongoDbClientFactory>().CreateClient());
        services.AddScoped(typeof(IGenericRepository<>), typeof(MongoRepository<>));
        services.AddScoped<IUnitOfWork, MongoUnitOfWork>();
        services.AddScoped(sp => (ITransactionManager)sp.GetRequiredService<IUnitOfWork>());
        services.AddScoped<IAggregateTracker, AggregateTracker>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateCustomerHandler).Assembly);
        });

        /* Using scan
        services.Scan(scan => scan
            .FromAssemblyOf<GetCustomerByIdHandler>()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()); */
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkTransactionBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DomainEventDispatchingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AggregateRootChangedBehavior<,>));

        return services;
    }
}
