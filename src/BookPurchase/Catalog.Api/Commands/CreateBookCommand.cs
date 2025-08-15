using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Commands;

public record CreateBookCommand(
    [property: Required, MaxLength(50)] string Title,
    [property: Required] string Description,
    [property: Required, MaxLength(100)] string Author
);
