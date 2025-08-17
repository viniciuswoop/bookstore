using BookPurchase.Web.App;
using BookPurchase.Web.Catalog;
using BookPurchase.Web.Catalog.Services;
using BookPurchase.Web.Catalog.Services.Abstractions;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
        .AddRazorComponents()
        .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddRadzenComponents();

builder.Services.AddHttpClient(CatalogConstants.CatalogApi, (opt) => 
{
    opt.BaseAddress = new Uri("https://localhost:7268/api/");
});
builder.Services.AddScoped<ICatalogService, CatalogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
