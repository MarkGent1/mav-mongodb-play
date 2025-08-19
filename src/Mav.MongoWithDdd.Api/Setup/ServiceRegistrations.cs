﻿using Asp.Versioning;
using Mav.MongoWithDdd.Infrastructure.MongoDb.Setup;
using Mav.MongoWithDdd.Infrastructure.Telemetry;

namespace Mav.MongoWithDdd.Api.Setup;

public static class ServiceRegistrations
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var config = builder.Configuration;

        services.AddLogging();

        services.AddApplicationInsightsApi(config);

        services.AddApiVersioning(options =>
        {
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddMongoDbDependencies(config);

        services.ConfigureHealthChecks();
    }

    private static void ConfigureHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks();
        //    .AddCheck<MongoDbHealthCheck>("mongodb", tags: ["db", "mongo"]);
    }
}
