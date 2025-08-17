namespace BookPurchase.Web.Catalog.Models;

public class BookListModel
{
    public string FilterValue { get; set; }

    public List<BookModel> Books { get; set; }
}
