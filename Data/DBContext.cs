using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data;

public class DBContext(DbContextOptions<DBContext> options)
    : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();
}