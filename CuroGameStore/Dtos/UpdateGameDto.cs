using System.ComponentModel.DataAnnotations;

namespace CuroGameStore.Dtos;

public record UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)]string Genre,
    [Range(1, 120)]decimal Price,
    DateOnly ReleaseDate
);

