var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    // Register all MediatR handlers from the current assembly
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();
