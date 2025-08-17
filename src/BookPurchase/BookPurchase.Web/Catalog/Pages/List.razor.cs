using BookPurchase.Web.Catalog.Models;
using BookPurchase.Web.Catalog.Services.Abstractions;
using Microsoft.AspNetCore.Components;

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
}
