var builder = WebApplication.CreateBuilder(args);

// Add controller services.
builder.Services.AddControllers();

var app = builder.Build();

// Map controller routes.
app.MapControllers();

app.Run();