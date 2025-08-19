using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.Api.Domains;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; private set; } = string.Empty;
    
    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string Author { get; private set; } = string.Empty;

    public bool Available {  get; private set; }

    public void SetOutOfStock()
    {
        Available = false;
    }

    public void SetAvailable()
    {
        Available = true;
    }

    public void Create(string title, string description, string author)
    {
        Id = Guid.NewGuid().ToString();
        Title = title;
        Description = description;
        Author = author;
        
        SetOutOfStock();
    }
}
