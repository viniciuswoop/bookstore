using Microsoft.AspNetCore.Components;

namespace BookPurchase.Web.Catalog.Components;

public partial class BookListFilter
{
    [Parameter] public required string SearchTerm { get; set; }
    [Parameter] public EventCallback<string> OnSearch { get; set; }

    private async Task Search()
    {
        if (OnSearch.HasDelegate)
        {
            await OnSearch.InvokeAsync(SearchTerm);
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
