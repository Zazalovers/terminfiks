using Microsoft.EntityFrameworkCore;
using TerminFiks.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// The Vite dev server runs on another port.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins(builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? [])
          .AllowAnyHeader()
          .AllowAnyMethod()));

var app = builder.Build();

// Create or update the SQLite tables on start, so a fresh clone works with one command.
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
}

app.UseCors();

app.MapGet("/health", async (AppDbContext db) =>
{
    var dbOk = await db.Database.CanConnectAsync();
    var body = new { status = dbOk ? "ok" : "degraded", database = dbOk ? "ok" : "unreachable" };
    return dbOk ? Results.Ok(body) : Results.Json(body, statusCode: 503);
});

app.Run();
