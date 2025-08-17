namespace AppHost;

public static class RabbitMqConstants
{
    public const string RabbitMq = "rabbitmq";
    public const string RabbitMqImage = "rabbitmq:3-management";
    public const string UsernameVariable = "rabbitmq-username";
    public const string PasswordVariable = "rabbitmq-password";
    public const string Amqp = "amqp";
    public const int AmqpPort = 5672;
    public const int AmqpTargetPort = 5672;
    public const int DashboardPort = 15672;
    public const int DashboardTargetPort = 15672;
}

public static class MongoDbConstants
{
    public const string MongoDb = "mongodb";
    public const string MongoImage = "mongo:6.0";
    public const int MongoDbPort = 27017;
    public const int MongoDbTargetPort = 27017;
    public const string UsernameVariable = "mongodb-username";
    public const string PasswordVariable = "mongodb-password";
}

public static class ProjectConstants
{
    public const string OrderApi = "order-api";
    public const string ShippmentApi = "shippment-api";
    public const string InventoryApi = "Inventory-api";
    public const string PaymentApi = "payment-api";
    public const string CatalogApi = "catalog-api";
    public const string PurchaseWebApp = "purchase-book-app";
}
