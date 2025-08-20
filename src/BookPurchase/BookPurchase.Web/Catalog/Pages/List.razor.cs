using BookPurchase.Web.Catalog.Models;
using BookPurchase.Web.Catalog.Services.Abstractions;
using BookPurchase.Web.Order.Components;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BookPurchase.Web.Catalog.Pages;

public partial class List
{
    public BookListModel Model { get; set; } = new();
    [Inject] ICatalogService CatalogService { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private async Task SearchBooks(string searchTerm)
    {
        Model.Books = await CatalogService.SearchAsync(searchTerm);
        StateHasChanged();
    }

    private async Task BookOrderAsync(string bookId)
    {
        // Opens your component in a dialog
        var result = await DialogService.OpenAsync<BookOrder>(
            "Book Order",
            new Dictionary<string, object>()
            {
                { "BookId", bookId }
            },
            new DialogOptions() { Width = "70%", Height = "80%", Resizable = true, Draggable = true }
        );

    }
}
