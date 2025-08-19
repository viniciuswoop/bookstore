using System.Net;
using Catalog.Api.Commands;
using Catalog.Api.Controllers;
using Catalog.Api.Domains;
using Catalog.Api.Repositories.Abstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Catalog.Api.UnitTests.Controllers
{
    public class CatalogControllerTests
    {
        private readonly Mock<ICatalogRepository> _catalogRepoMock;
        private readonly CatalogController _sut;

        public CatalogControllerTests()
        {
            _catalogRepoMock = new();

            _sut = new(_catalogRepoMock.Object);
        }

        [Fact]
        public async Task WhenAddingInvalidRequest_ThenReturnBadRequest()
        {
            // arrange
            CreateBookCommand? cmd = default(CreateBookCommand);
            _sut.ModelState.AddModelError("Title", "Required");

            // act
            var response = await _sut.AddBookAsync(cmd!);

            // assert
            _catalogRepoMock.Verify(v => v.AddAsync(It.IsAny<Book>()), Times.Never());
        }

        [Fact]
        public async Task WhenAddingValidRequest_ThenCreateTheBook()
        {
            // arrange
            CreateBookCommand cmd = new("DDD", "Awesome book", "Eric Evans");
            _catalogRepoMock
                .Setup(s =>
                    s.AddAsync(
                        It.Is<Book>(b =>
                            b.Title == cmd.Title
                            && b.Description == cmd.Description
                            && b.Author == cmd.Author
                            && b.Available == false
                            && !string.IsNullOrWhiteSpace(b.Id)
                        )
                    )
                )
                .Returns(Task.CompletedTask)
                .Verifiable();

            // act
            var response = await _sut.AddBookAsync(cmd);

            // assert
            response.Should().BeOfType<CreatedAtActionResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        [Fact]
        public async Task WhenQueryingAllBooks_ThenReturnBookList()
        {
            // arrange
            var dddBook = new Book();
            dddBook.Create("DDD", "Fantastic", "Eric Evans");

            _catalogRepoMock
                .Setup(s => s.GetAllAsync())
                .ReturnsAsync(new List<Book>()
                {
                    dddBook
                })
                .Verifiable();

            // act
            var response = await _sut.GetBooksAsync(string.Empty);

            // assert
            var booksResponse = response
                .Should()
                .BeOfType<OkObjectResult>()
                .Subject
                .Value
                .Should()
                .BeOfType<List<Book>>();
            booksResponse.Subject.Count.Should().Be(1);
            _catalogRepoMock.Verify();
        }
    }
}
