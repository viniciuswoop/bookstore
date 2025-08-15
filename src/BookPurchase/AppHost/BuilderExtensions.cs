namespace AppHost;

public static class BuilderExtensions
{
    private static IResourceBuilder<RabbitMQServerResource> _rabbitMq;
    private static IResourceBuilder<MongoDBServerResource> _mongoDb;

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
        var orderService = builder.AddProject<Projects.Order_Api>(ProjectConstants.OrderApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterInventtoryApi(this IDistributedApplicationBuilder builder)
    {
        var inventoryService = builder.AddProject<Projects.Inventory_Api>(ProjectConstants.InventoryApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterPaymentApi(this IDistributedApplicationBuilder builder)
    {
        var paymentService = builder.AddProject<Projects.Payment_Api>(ProjectConstants.PaymentApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterShippmentApi(this IDistributedApplicationBuilder builder)
    {
        var shippingService = builder.AddProject<Projects.Shipping_Api>(ProjectConstants.ShippmentApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }

    public static IDistributedApplicationBuilder RegisterCatalogApi(this IDistributedApplicationBuilder builder)
    {
        var shippingService = builder.AddProject<Projects.Catalog_Api>(ProjectConstants.CatalogApi)
            .WithReference(_rabbitMq)
            .WithReference(_mongoDb);

        return builder;
    }
}