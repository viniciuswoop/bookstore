using BookPurchase.Web.Catalog.Models;

namespace BookPurchase.Web.Order.Models;

public class BookOrderModel
{
    public string BookId { get; set; } = string.Empty;
    public string BookTitle { get; set; } = string.Empty;
    public int Amount { get; set; }
    public CardInfoModel CardInfo { get; set; } = new();
    public AddressInfoModel AddressInfo { get; set; } = new();

    public void SetBookInfo(BookModel? bookInfo)
    {
        if (bookInfo is not null)
        {
            BookTitle = bookInfo.Title;
            BookId = bookInfo.Id;
        }
    }
}

public class CardInfoModel
{
    public string Number { get; set; } = string.Empty;
    public string ExpiresIn { get; set; } = string.Empty;
    public string SecurityCode { get; set; } = string.Empty; 
}

public class AddressInfoModel
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string StateOrProvince { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}

