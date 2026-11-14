using test;
using test.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

List<GameDto> game = [
    new(1, "Nike Air Max", "Shoes", 12500.00m),
    new(2, "Samsung Galaxy S24", "Electronics", 245000.00m),
    new(3, "Apple MacBook Air", "Laptop", 385000.00m),
    new(4, "Adidas Ultraboost", "Shoes", 32000.00m),
    new(5, "Sony WH-1000XM5", "Headphones", 85000.00m)
];

app.MapGet("/", () => game);

app.MapGet("/{id}", (int id) => game.Find(game => game.Id == id));

app.MapPost("/",(CreateGameDto newgame) =>
{
    
});

app.Run();
