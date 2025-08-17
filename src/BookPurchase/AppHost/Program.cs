
using AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.RegisterRabbit()
        .RegisterMongoDb()
        .RegisterOrderApi()
        .RegisterInventoryApi()
        .RegisterPaymentApi()
        .RegisterShippmentApi()
        .RegisterCatalogApi()
        .RegisterBookPurchaseWeb()
        .Build()
        .Run();
