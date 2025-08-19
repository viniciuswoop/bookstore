using Catalog.Api.Domains;
using FluentAssertions;

namespace Catalog.Api.UnitTests.Domains;

public class BookTests
{
    [Fact]
    public void WhenCreating_ThenSetProperties()
    {
        // Arrange
        string title = "Domain-Driven Design: Tackling Complexity in the Heart of Software";
        string description = "Good book";
        string author = "Eric Evans";
        
        // Act
        Book book = new();
        book.Create("Domain-Driven Design: Tackling Complexity in the Heart of Software", "Good book", "Eric Evans");

        // Assert
        book.Id.Should().NotBeNullOrEmpty();
        book.Title.Should().Be(title);
        book.Description.Should().Be(description);
        book.Author.Should().Be(author);
        book.Available.Should().BeFalse(); 
    }

    [Fact]
    public void WhenSetAvailable_ThenBookIsAvailable()
    {
        // Arrange
        Book book = new();
        book.Create("Domain-Driven Design: Tackling Complexity in the Heart of Software", "Good book", "Eric Evans");

        // Act
        book.SetAvailable();

        // Assert
        book.Available.Should().BeTrue();
    }
}
