namespace BookPurchase.Web.Catalog.Models;

public class BookModel
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool Available { get; set; }
}
