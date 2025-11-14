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
}

app.MapGraphQL();

app.Run();
