using Catalog.Api.Commands;
using Catalog.Api.Domains;
using Catalog.Api.Repositories;
using Catalog.Api.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly ICatalogRepository _repository;

    public CatalogController(ICatalogRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("books/{id}")]
    public async Task<IActionResult> GetBook(string id)
    {
        var book = await _repository.GetByIdAsync(id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpGet("books")]
    public async Task<IActionResult> GetBooks() => Ok(await _repository.GetAllAsync());

    [HttpPost("books")]
    public async Task<IActionResult> AddBook([FromBody] CreateBookCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var book = new Book();
        book.Create(command.Title, command.Description, command.Author);

        await _repository.AddAsync(book);
        
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }
}
