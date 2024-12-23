using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos;

public record class UpdateGameDto(
    [Required][StringLength(128)] string Name,
    int GenreId,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);