using Catalog.Api.Repositories;
using Catalog.Api.Repositories.Abstractions;
using Catalog.Api.Settings;
using MongoDB.Driver;

namespace Catalog.Api.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<IMongoClient>((sp) =>
        {
            MongoDbSettings? settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
            return new MongoClient(settings.ConnectionString);
        });
        

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICatalogRepository, CatalogRepository>();

        return services;
    }
}
