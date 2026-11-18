using System.ComponentModel.DataAnnotations;
namespace test.Dtos;

public record CreateGameDto(

    [Required]string Name,
    [Required]string Genre,
    [Required]decimal Price
);
