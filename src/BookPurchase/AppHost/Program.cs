
using AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Catalog_Api>("catalog-api");

builder.RegisterRabbit()
        .RegisterMongoDb()
        .RegisterOrderApi()
        .RegisterInventtoryApi()
        .RegisterPaymentApi()
        .RegisterShippmentApi()
        .Build()
        .Run();
