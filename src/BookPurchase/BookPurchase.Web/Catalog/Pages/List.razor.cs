using BookPurchase.Web.Catalog.Models;

namespace BookPurchase.Web.Catalog.Pages;

public partial class List
{
    public BookListModel Model { get; set; }

    protected override void OnInitialized()
    {
        Model = new BookListModel();
        base.OnInitialized();
    }
}
