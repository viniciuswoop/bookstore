using Catalog.Api.Domains;

namespace Catalog.Api.Repositories.Abstractions;

public interface ICatalogRepository
{
    Task<List<Book>> GetAllAsync();

    Task<Book?> GetByIdAsync(string id);

    Task AddAsync(Book book);

    Task UpdateAsync(Book book);
}
