using Microsoft.EntityFrameworkCore;
using test.Endpoints;
using test.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddValidation();

// Database connection string
var connString = "Data Source=games.db";

// Register DbContext
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlite(connString));

var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();