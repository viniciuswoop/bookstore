using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects;

namespace AppHost;

public static class RabbitMqConstants
{
    public const string RabbitMq = "rabbitmq";
    public const string RabbitMqImage = "rabbitmq:3-management";
    public const string UsernameVariable = "RABBITMQ_DEFAULT_USER";
    public const string PasswordVariable = "RABBITMQ_DEFAULT_PASS";
    public const string Username = "admin";
    public const string Password = "admin";
    public const string Amqp = "amqp";
    public const int AmqpPort = 5672;
    public const int AmqpTargetPort = 5672;
    public const int DashboardPort = 15672;
    public const int DashboardTargetPort = 15672;
}

public static class MongoDbConstants
{
    public const string MongoDb = "mongodb";
    public const string MongoImage = "mongo:7.0";
    public const int MongoDbPort = 27017;
    public const int MongoDbTargetPort = 27017;
    public const string UsernameVariable = "MONGO_INITDB_ROOT_USERNAME";
    public const string PasswordVariable = "MONGO_INITDB_ROOT_PASSWORD";
    public const string Username = "admin";
    public const string Password = "password";
}

public static class ProjectConstants
{
    public const string OrderApi = "order-api";
    public const string ShippmentApi = "shippment-api";
    public const string InventoryApi = "Inventory-api";
    public const string PaymentApi = "payment-api";
}
