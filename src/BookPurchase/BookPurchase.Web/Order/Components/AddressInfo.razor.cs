using BookPurchase.Web.Order.Models;
using Microsoft.AspNetCore.Components;

namespace BookPurchase.Web.Order.Components;

public partial class AddressInfo : ComponentBase
{
    [Parameter] public AddressInfoModel Value { get; set; }
    [Parameter] public EventCallback<AddressInfoModel> ValueChanged { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}
