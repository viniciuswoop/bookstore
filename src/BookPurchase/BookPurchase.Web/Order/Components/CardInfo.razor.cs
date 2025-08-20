using BookPurchase.Web.Order.Models;
using Microsoft.AspNetCore.Components;

namespace BookPurchase.Web.Order.Components;

public partial class CardInfo : ComponentBase
{
    [Parameter] public CardInfoModel Value { get; set; }
    [Parameter] public EventCallback<CardInfoModel> ValueChanged { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
