var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        var origins = builder.Configuration["FrontendOrigins"]
            ?.Split(',', StringSplitOptions.RemoveEmptyEntries
                | StringSplitOptions.TrimEntries);

        policy.WithOrigins(
            origins is { Length: > 0 }
                ? origins
                : new[] { "http://localhost:5173" })
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("Frontend");

app.MapGet("/health", () =>
    Results.Ok(new
    {
        status = "Healthy",
        application = "CampusEats API"
    }));

var menu = new[]
{
    new MenuItem(1, "Chicken Rice", 650, "Rice and curry"),
    new MenuItem(2, "Vegetable Noodles", 450, "Vegetarian meal"),
    new MenuItem(3, "Chicken Burger", 850, "Burger and fries"),
    new MenuItem(4, "Fresh Juice", 300, "Fresh fruit drink")
};

app.MapGet("/api/menu", () => Results.Ok(menu));

app.MapGet("/api/menu/{id:int}", (int id) =>
{
    var item = menu.FirstOrDefault(x => x.Id == id);

    return item is null
        ? Results.NotFound()
        : Results.Ok(item);
});

app.Run();

record MenuItem(
    int Id,
    string Name,
    decimal Price,
    string Description
);