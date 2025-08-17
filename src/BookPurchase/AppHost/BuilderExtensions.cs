namespace AppHost;

public static class BuilderExtensions
{
    private static IResourceBuilder<RabbitMQServerResource> _rabbitMq;
    private static IResourceBuilder<MongoDBServerResource> _mongoDb;
    private static IResourceBuilder<ProjectResource> _orderApi;
    private static IResourceBuilder<ProjectResource> _inventoryApi;
    private static IResourceBuilder<ProjectResource> _paymentApi;
    private static IResourceBuilder<ProjectResource> _shipmentApi;
    private static IResourceBuilder<ProjectResource> _catalogApi;

    public static IDistributedApplicationBuilder RegisterRabbit(this IDistributedApplicationBuilder builder)
    {
        var username = builder.AddParameter(RabbitMqConstants.UsernameVariable);
        var password = builder.AddParameter(RabbitMqConstants.PasswordVariable);

        _rabbitMq = builder.AddRabbitMQ(RabbitMqConstants.RabbitMq, userName: username, password: password)
                            .WithImage(RabbitMqConstants.RabbitMqImage)
                            .WithEndpoint(name: RabbitMqConstants.Amqp, port: RabbitMqConstants.AmqpPort, targetPort: RabbitMqConstants.AmqpTargetPort)
                            .WithHttpEndpoint(RabbitMqConstants.DashboardPort, RabbitMqConstants.DashboardTargetPort);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterMongoDb(this IDistributedApplicationBuilder builder)
    {
        var username = builder.AddParameter(MongoDbConstants.UsernameVariable);
        var password = builder.AddParameter(MongoDbConstants.PasswordVariable);

        _mongoDb = builder.AddMongoDB(MongoDbConstants.MongoDb, userName: username, password: password)
                            .WithImage(MongoDbConstants.MongoImage)
                            .WithHttpsEndpoint(MongoDbConstants.MongoDbPort, MongoDbConstants.MongoDbTargetPort);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterOrderApi(this IDistributedApplicationBuilder builder)
    {
        _orderApi = builder.AddProject<Projects.Order_Api>(ProjectConstants.OrderApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterInventoryApi(this IDistributedApplicationBuilder builder)
    {
        _inventoryApi = builder.AddProject<Projects.Inventory_Api>(ProjectConstants.InventoryApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterPaymentApi(this IDistributedApplicationBuilder builder)
    {
        _paymentApi = builder.AddProject<Projects.Payment_Api>(ProjectConstants.PaymentApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterShippmentApi(this IDistributedApplicationBuilder builder)
    {
        _shipmentApi = builder.AddProject<Projects.Shipping_Api>(ProjectConstants.ShippmentApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterCatalogApi(this IDistributedApplicationBuilder builder)
    {
        _catalogApi = builder.AddProject<Projects.Catalog_Api>(ProjectConstants.CatalogApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterBookPurchaseWeb(this IDistributedApplicationBuilder builder)
    {
        var shippingService = builder.AddProject<Projects.BookPurchase_Web>(ProjectConstants.PurchaseWebApp)
            .WithReference(_orderApi)
            .WithReference(_inventoryApi)
            .WithReference(_paymentApi)
            .WithReference(_shipmentApi)
            .WithReference(_catalogApi);

        return builder;
    }
}