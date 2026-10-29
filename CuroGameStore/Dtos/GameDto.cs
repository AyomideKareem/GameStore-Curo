namespace CuroGameStore.Dtos;

public record GameDto(
    int Id,
    string Name,
    string genre,
    decimal Price,
    DateOnly ReleaseDate
);

