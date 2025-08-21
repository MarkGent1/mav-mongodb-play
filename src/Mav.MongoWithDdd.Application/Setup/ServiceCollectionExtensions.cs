using FluentValidation;
using Mav.MongoWithDdd.Application.Queries.Customers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mav.MongoWithDdd.Application.Setup;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRequestExecutor, RequestExecutor>();
        services.AddValidatorsFromAssemblyContaining<GetCustomerByIdValidator>();

        return services;
    }
}
