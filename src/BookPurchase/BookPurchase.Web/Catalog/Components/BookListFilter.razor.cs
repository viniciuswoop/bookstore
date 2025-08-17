using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BookPurchase.Web.Catalog.Components;

public partial class BookListFilter
{
    [Parameter] public string FilterValue { get; set; }

    private void SearchAsync()
    {
        
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
