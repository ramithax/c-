using test.Dtos;
namespace test.Endpoints;

public static class GamesEndpoints
{
    private static readonly List<GameDto> games = [
    new(1, "Nike Air Max", "Shoes", 12500.00m),
    new(2, "Samsung Galaxy S24", "Electronics", 245000.00m),
    new(3, "Apple MacBook Air", "Laptop", 385000.00m),
    new(4, "Adidas Ultraboost", "Shoes", 32000.00m),
    new(5, "Sony WH-1000XM5", "Headphones", 85000.00m)
];

public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
{

var group = app.MapGroup("/games");
        
group.MapGet("/", () => games);

group.MapGet("/{id}", (int id) =>
{
    var game = games.Find(game => game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
}
).WithName("GetGame");

group.MapPost("/",(CreateGameDto newgame) =>
{
    GameDto game = new(
    games.Count + 1,
    newgame.Name,
    newgame.Genre,
    newgame.Price    
    );

    games.Add(game);
    return Results.CreatedAtRoute("GetGame",new{id = game.Id}, game);
});

group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>

{
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
    
    {
        return Results.NotFound();
    }
    
    games[index] = new GameDto(
    id,
    updatedGame.Name,
    updatedGame.Genre,
    updatedGame.Price
    );

    return Results.NoContent();
});

group.MapDelete("/{id}", (int id) =>

{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});    

    return group;
}
}
