using Catalog.Api.Domains;
using Catalog.Api.Repositories.Abstractions;
using Catalog.Api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Api.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly IMongoCollection<Book> _books;

    public CatalogRepository(IMongoClient client, IOptions<MongoDbSettings> dbSetting)
    {
        var db = client.GetDatabase(dbSetting.Value.Database);
        _books = db.GetCollection<Book>("books");
    }

    public async Task<List<Book>> GetAllAsync() =>
        await _books.Find(_ => true).ToListAsync();

    public async Task<Book?> GetByIdAsync(string id) =>
        await _books.Find(b => b.Id == id).FirstOrDefaultAsync();

    public async Task AddAsync(Book book) =>
        await _books.InsertOneAsync(book);

    public async Task UpdateAsync(Book book) =>
        await _books.ReplaceOneAsync(b => b.Id == book.Id, book);
}
