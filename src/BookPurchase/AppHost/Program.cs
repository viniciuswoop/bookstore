
using AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.RegisterRabbit()
        .RegisterMongoDb()
        .RegisterOrderApi()
        .RegisterInventtoryApi()
        .RegisterPaymentApi()
        .RegisterShippmentApi()
        .Build()
        .Run();

