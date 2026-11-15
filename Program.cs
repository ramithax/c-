using test;
using test.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

List<GameDto> games = [
    new(1, "Nike Air Max", "Shoes", 12500.00m),
    new(2, "Samsung Galaxy S24", "Electronics", 245000.00m),
    new(3, "Apple MacBook Air", "Laptop", 385000.00m),
    new(4, "Adidas Ultraboost", "Shoes", 32000.00m),
    new(5, "Sony WH-1000XM5", "Headphones", 85000.00m)
];

app.MapGet("/", () => games);

app.MapGet("/{id}", (int id) =>
{
    var game = games.Find(game => game.Id == id);

    return game is null ? Results.NotFound() : Results.Ok();
}
).WithName("GetGame");

app.MapPost("/",(CreateGameDto newgame) =>
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

app.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>

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

app.MapDelete("/{id}", (int id) =>

{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});

app.Run();
