using DateTimeReproduction.Api;
using DateTimeReproduction.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services
    .AddGraphQLServer()
    .AddSorting()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddQueryType<Query>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Events.Any())
    {
        db.Events.AddRange(
            new Event
            {
                Name = "Conference Keynote",
                Timestamp = new DateTimeOffset(2025, 11, 14, 9, 0, 0, TimeSpan.FromHours(1))
            },
            new Event
            {
                Name = "Workshop Session",
                Timestamp = new DateTimeOffset(2025, 11, 14, 14, 30, 0, TimeSpan.FromHours(1))
            },
            new Event
            {
                Name = "Networking Event",
                Timestamp = new DateTimeOffset(2025, 11, 15, 18, 0, 0, TimeSpan.FromHours(1))
            },
            new Event
            {
                Name = "Product Launch",
                Timestamp = new DateTimeOffset(2025, 11, 16, 10, 0, 0, TimeSpan.FromHours(1))
            },
            new Event
            {
                Name = "Team Meeting",
                Timestamp = new DateTimeOffset(2025, 11, 17, 13, 0, 0, TimeSpan.FromHours(1))
            }
        );
        db.SaveChanges();
    }
}

app.MapGraphQL();

app.Run();
