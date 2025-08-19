using BookPurchase.Web.Catalog.Services.Abstractions;
using BookPurchase.Web.Order.Models;
using Microsoft.AspNetCore.Components;

namespace BookPurchase.Web.Order.Components;

public partial class BookOrder
{
    [Parameter] public string BookId { get; set; }
    BookOrderModel Model { get; set; } = new();
    [Inject] ICatalogService CatalogService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var book = await CatalogService.GetBookAsync(BookId);

        Model.SetBookInfo(book);
        
        base.OnInitialized();
    }

    private async Task CreateOrderAsync()
    {
        
    }
}
