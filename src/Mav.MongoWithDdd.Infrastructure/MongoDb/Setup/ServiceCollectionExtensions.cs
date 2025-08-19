using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mav.MongoWithDdd.Infrastructure.MongoDb.Setup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDbDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoConfig>(configuration.GetSection("Mongo"));

        return services;
    }
}
