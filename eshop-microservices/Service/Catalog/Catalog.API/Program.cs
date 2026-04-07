var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCarter();
var assemnly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    // Register all MediatR handlers from the current assembly
    config.RegisterServicesFromAssembly(assemnly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assemnly);

builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
    // Configure Marten to connect to the PostgreSQL database
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
