namespace Catalog.Api.Settings;

public class MongoDbSettings
{
    public string ConnectionString { get; init; } = string.Empty;
    public string Database { get; set; } = string.Empty;
}
