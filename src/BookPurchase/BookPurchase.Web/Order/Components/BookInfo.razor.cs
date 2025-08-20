using BookPurchase.Web.Order.Models;
using Microsoft.AspNetCore.Components;

namespace BookPurchase.Web.Order.Components;

public partial class BookInfo : ComponentBase
{
    [Parameter] public BookInfoViewModel Value { get; set; }
    [Parameter] public EventCallback<BookInfoViewModel> ValueChanged { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
