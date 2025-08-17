using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Commands;

public record CreateBookCommand(
    [Required, MaxLength(50)] string Title,
    [Required] string Description,
    [Required, MaxLength(100)] string Author
);
