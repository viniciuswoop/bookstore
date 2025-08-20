using BookPurchase.Web.Catalog.Services.Abstractions;
using BookPurchase.Web.Order.Models;
using Microsoft.AspNetCore.Components;

namespace BookPurchase.Web.Order.Components;

public partial class BookOrder 
{
    [Parameter] public required string BookId { get; set; }
    
    [Inject] public required ICatalogService CatalogService { get; set; }
    
    [SupplyParameterFromForm] protected BookOrderModel Model { get; set; } = new();

    
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
