using BookPurchase.Web.Catalog.Models;

namespace BookPurchase.Web.Catalog.Services.Abstractions;

public interface ICatalogService
{
    Task<List<BookModel>> SearchAsync(string searchTerm);
    Task<BookModel?> GetBookAsync(string id);
}
