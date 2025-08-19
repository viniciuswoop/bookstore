using BookPurchase.Web.Catalog.Models;
using BookPurchase.Web.Catalog.Services.Abstractions;

namespace BookPurchase.Web.Catalog.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(CatalogConstants.CatalogApi);
    }

    public async Task<List<BookModel>> SearchAsync(string? searchTerm)
    {
        var response = await _httpClient.GetAsync($"catalog/books?searchTerm={Uri.EscapeDataString(searchTerm ?? string.Empty)}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<BookModel>>() ?? new List<BookModel>();
    }

    public async Task<BookModel?> GetBookAsync(string id)
    {
        var response = await _httpClient.GetAsync($"catalog/books/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<BookModel>();
    }
}
