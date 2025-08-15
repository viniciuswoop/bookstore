using Catalog.Api.Extensions;
using Catalog.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services
    .AddOpenApi()
    .AddMongo(builder.Configuration)
    .AddRepositories();

var app = builder.Build();

app.UseMiddleware<ExceptionLoggingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API v1");
        c.RoutePrefix = "swagger"; // URL: /swagger
    });
}

app.UseHttpsRedirection();

app.UseHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();
