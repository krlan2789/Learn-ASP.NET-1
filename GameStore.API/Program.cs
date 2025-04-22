using GameStore.API.Data;
using GameStore.API.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Database Context services
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

// Adds OpenAPI services
builder.Services.AddOpenApi();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
// }
string openApiRoute = "/docs/{documentName}/openapi.json";
// Register the endpoint for viewing the OpenAPI
app.MapOpenApi(openApiRoute);
app.MapScalarApiReference(options =>
{
    string scalarApiRoute = "/docs/{documentName}";
    options
        .WithTitle("Game Store - REST API")
        .WithTheme(ScalarTheme.BluePlanet)
        .WithEndpointPrefix(scalarApiRoute)
        .WithOpenApiRoutePattern(openApiRoute)
        ;
});

// Register all endpoints
app.MapGamesEndpoints();
app.MapGenresEndpoints();

// Migrate the database
await app.MigrateDbAsync();

app.Run();
