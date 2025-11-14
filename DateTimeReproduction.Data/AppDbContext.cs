using Microsoft.EntityFrameworkCore;

namespace DateTimeReproduction.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
}
