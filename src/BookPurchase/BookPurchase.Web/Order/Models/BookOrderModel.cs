using BookPurchase.Web.Catalog.Models;
using System.ComponentModel.DataAnnotations;

namespace BookPurchase.Web.Order.Models;

public class BookOrderModel
{
    [ValidateComplexType]
    public BookInfoViewModel BookInfo { get; set; } = new();

    [ValidateComplexType]
    public CardInfoModel CardInfo { get; set; } = new();

    [ValidateComplexType]
    public AddressInfoModel AddressInfo { get; set; } = new();

    public void SetBookInfo(BookModel? bookInfo)
    {
        if (bookInfo is not null)
        {
            BookInfo.BookTitle = bookInfo.Title;
            BookInfo.BookId = bookInfo.Id;
        }
    }
}

public class BookInfoViewModel
{
    public string BookId { get; set; } = string.Empty;

    public string BookTitle { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Please inform an Amount.")]
    public int Amount { get; set; }
}

public class CardInfoModel
{
    [Required]
    public string Number { get; set; } = string.Empty;
    
    [Required]
    public string ExpiresIn { get; set; } = string.Empty;
    
    [Required]
    public string SecurityCode { get; set; } = string.Empty; 
}

public class AddressInfoModel
{
    [Required]
    public string Street { get; set; } = string.Empty;
    
    [Required]
    public string City { get; set; } = string.Empty;
    
    [Required]
    public string StateOrProvince { get; set; } = string.Empty;
    
    [Required]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    public string Country { get; set; } = string.Empty;
}

