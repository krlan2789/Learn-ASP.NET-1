using GameStore.API.Data;
using GameStore.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

// Register all endpoints
app.MapGamesEndpoints();
app.MapGenresEndpoints();

// Migrate the database
await app.MigrateDbAsync();

app.Run();
